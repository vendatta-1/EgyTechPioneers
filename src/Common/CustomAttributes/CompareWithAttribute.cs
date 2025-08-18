using System.ComponentModel.DataAnnotations;

namespace Common.CustomAttributes;

public class CompareWithAttribute(string otherProperty, ComparisonType comparisonType) : ValidationAttribute
{
  

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var otherProp = validationContext.ObjectType.GetProperty(otherProperty);
        if (otherProp == null)
            return new ValidationResult($"Unknown property: {otherProperty}");

        var otherValue = otherProp.GetValue(validationContext.ObjectInstance);

        // Handle nullability rules
        if (value == null && otherValue == null) return ValidationResult.Success;
        if(value ==null)return ValidationResult.Success;
        if ( otherValue == null) return new ValidationResult($"{otherProperty} cannot be null"); 

        if (value is IComparable v1 && otherValue is IComparable v2)
        {
            int cmp = v1.CompareTo(v2);

            bool isValid = comparisonType switch
            {
                ComparisonType.Equal => cmp == 0,
                ComparisonType.NotEqual => cmp != 0,
                ComparisonType.GreaterThan => cmp > 0,
                ComparisonType.GreaterThanOrEqual => cmp >= 0,
                ComparisonType.LessThan => cmp < 0,
                ComparisonType.LessThanOrEqual => cmp <= 0,
                _ => true
            };

            if (!isValid)
                return new ValidationResult($"{validationContext.MemberName} must be {comparisonType} {otherProperty}");
        }

        return ValidationResult.Success;
    }
}