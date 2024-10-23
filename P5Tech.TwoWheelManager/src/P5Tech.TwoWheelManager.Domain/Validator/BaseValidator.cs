using FluentValidation;
using System;

namespace P5Tech.TwoWheelManager.Domain.Validator
{
    public class BaseValidator
    {
        protected const string DEFAULT_MESSAGE = "The value object of {0} is null or invalid.";

        public static void Validate<T>(T value, AbstractValidator<T> validator, string defaultMessage) where T : class
        {
            if (value == null)
                throw new Exception(defaultMessage);

            validator.ValidateAndThrow(value);
        }

        public static void Validate<T>(T value, AbstractValidator<T> validator) where T : class
            => Validate(value, validator, string.Format(DEFAULT_MESSAGE, typeof(T)));
    }
}