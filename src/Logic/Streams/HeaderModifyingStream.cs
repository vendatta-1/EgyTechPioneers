namespace Logic.Streams;

/// <summary>
/// A Stream wrapper that buffers an initial "preamble" of data.
/// This allows a middleware to modify response headers after the controller
/// has written its initial content, but before any data is sent to the client.
/// After headers are modified, the buffered preamble is sent, and subsequent writes
/// are passed directly to the inner stream.
/// </summary>
public class HeaderModifyingStream : Stream
{
    private readonly Stream _innerStream;
    private readonly MemoryStream _preambleBuffer = new MemoryStream();
    private bool _preambleSent = false;

    public HeaderModifyingStream(Stream innerStream)
    {
        _innerStream = innerStream;
    }

    // Properties for stream capabilities. This stream is designed for writing only.
    public override bool CanRead => false;
    public override bool CanSeek => false;
    public override bool CanWrite => true;

    // Length of the stream. Combines buffered data and inner stream's length if preamble sent.
    public override long Length => _preambleBuffer.Length + (_preambleSent ? _innerStream.Length : 0);

    // Position is complex for wrapper streams. For this use case, setting is not supported.
    public override long Position
    {
        get => _preambleBuffer.Position + (_preambleSent ? _innerStream.Position : 0);
        set => throw new NotSupportedException("Setting position is not supported on HeaderModifyingStream.");
    }

    /// <summary>
    /// Explicitly disallows synchronous Flush. All consumers must use FlushAsync.
    /// </summary>
    public override void Flush() => throw new NotSupportedException("Synchronous operations are disallowed. Use FlushAsync instead.");

    /// <summary>
    /// Explicitly disallows synchronous Read. Reading is not supported by this write-only stream.
    /// </summary>
    public override int Read(byte[] buffer, int offset, int count) => throw new NotSupportedException("Reading is not supported on HeaderModifyingStream.");

    /// <summary>
    /// Explicitly disallows synchronous Seek. Seeking is not supported by this stream.
    /// </summary>
    public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException("Seeking is not supported on HeaderModifyingStream.");

    /// <summary>
    /// Explicitly disallows synchronous SetLength. Setting length is not supported by this stream.
    /// </summary>
    public override void SetLength(long value) => throw new NotSupportedException("Setting length is not supported on HeaderModifyingStream.");

    /// <summary>
    /// Explicitly disallows synchronous Write. All consumers must use WriteAsync.
    /// </summary>
    public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException("Synchronous operations are disallowed. Use WriteAsync instead.");

    /// <summary>
    /// Writes data to the stream asynchronously. Data is buffered in preamble until SendPreambleAsync is called.
    /// After preamble is sent, data is written directly to the inner stream.
    /// </summary>
    /// <param name="buffer">The buffer to write data from.</param>
    /// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes.</param>
    /// <param name="count">The number of bytes to be written.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous write operation.</returns>
    public override async Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
    {
        if (_preambleSent)
        {
            await _innerStream.WriteAsync(buffer, offset, count, cancellationToken);
        }
        else
        {
            // Buffer the data until the middleware has a chance to inspect and modify headers.
            // This small buffer allows the middleware to complete its logic *before* the first byte hits the network.
            await _preambleBuffer.WriteAsync(buffer, offset, count, cancellationToken);
        }
    }

    /// <summary>
    /// Asynchronously flushes all buffers to the underlying stream.
    /// This method ensures the preamble is sent before flushing the inner stream.
    /// </summary>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous flush operation.</returns>
    public override async Task FlushAsync(CancellationToken cancellationToken)
    {
        // Ensure preamble is sent before flushing the inner stream
        await SendPreambleAsync();
        await _innerStream.FlushAsync(cancellationToken);
    }

    /// <summary>
    /// Sends the buffered preamble data to the inner stream asynchronously.
    /// This method should be called by the middleware after all header modifications are complete.
    /// </summary>
    /// <returns>A task that represents the asynchronous preamble sending operation.</returns>
    public async Task SendPreambleAsync()
    {
        if (!_preambleSent)
        {
            _preambleBuffer.Position = 0;
            // Use CopyToAsync for asynchronous copy of the buffered preamble.
            await _preambleBuffer.CopyToAsync(_innerStream);
            _preambleSent = true;
        }
    }
}