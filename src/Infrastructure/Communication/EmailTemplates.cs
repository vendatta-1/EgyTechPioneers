namespace Infrastructure.Communication;

public static class EmailTemplates
{
    public static string ConfirmationEmail(string link) => $"""
                                                                <div style="font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;">
                                                                    <div style="max-width: 600px; margin: auto; background: white; border-radius: 10px; overflow: hidden; box-shadow: 0 2px 8px rgba(0,0,0,0.1);">
                                                                        <div style="background-color: #007BFF; padding: 20px; color: white; text-align: center;">
                                                                            <h1>Confirm Your Email</h1>
                                                                        </div>
                                                                        <div style="padding: 30px; text-align: center;">
                                                                            <p>Click the button below to confirm your email address:</p>
                                                                            <a href="{link}" style="display: inline-block; margin-top: 20px; padding: 12px 24px; background-color: #28a745; color: white; text-decoration: none; border-radius: 5px;">
                                                                                Confirm Email
                                                                            </a>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            """;

    public static string PasswordReset(string link) => $"""
                                                            <div style="font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;">
                                                                <div style="max-width: 600px; margin: auto; background: white; border-radius: 10px; overflow: hidden; box-shadow: 0 2px 8px rgba(0,0,0,0.1);">
                                                                    <div style="background-color: #dc3545; padding: 20px; color: white; text-align: center;">
                                                                        <h1>Password Reset</h1>
                                                                    </div>
                                                                    <div style="padding: 30px; text-align: center;">
                                                                        <p>Forgot your password? No problem.</p>
                                                                        <a href="{link}" style="display: inline-block; margin-top: 20px; padding: 12px 24px; background-color: #dc3545; color: white; text-decoration: none; border-radius: 5px;">
                                                                            Reset Password
                                                                        </a>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        """;

    public static string TwoFactorCode(string code) => $"""
                                                            <div style="font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;">
                                                                <div style="max-width: 600px; margin: auto; background: white; border-radius: 10px; overflow: hidden; box-shadow: 0 2px 8px rgba(0,0,0,0.1);">
                                                                    <div style="background-color: #ffc107; padding: 20px; color: black; text-align: center;">
                                                                        <h1>Two-Factor Verification</h1>
                                                                    </div>
                                                                    <div style="padding: 30px; text-align: center;">
                                                                        <p>Your one-time verification code is:</p>
                                                                        <div style="font-size: 28px; font-weight: bold; margin-top: 20px;">{code}</div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        """;

    public static string WelcomeEmail(string email) => $"""
                                                            <div style="font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;">
                                                                <div style="max-width: 600px; margin: auto; background: white; border-radius: 10px; overflow: hidden; box-shadow: 0 2px 8px rgba(0,0,0,0.1);">
                                                                    <div style="background-color: #17a2b8; padding: 20px; color: white; text-align: center;">
                                                                        <h1>Welcome!</h1>
                                                                    </div>
                                                                    <div style="padding: 30px; text-align: center;">
                                                                        <p>Hello <strong>{email}</strong>,</p>
                                                                        <p>We're thrilled to have you join our platform. Let's achieve something amazing together!</p>
                                                                        <p style="margin-top: 30px;">– The Team</p>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        """;
}