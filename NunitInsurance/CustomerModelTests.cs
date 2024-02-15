using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // it is used for validations
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;

namespace NunitInsurance
{
    [TestFixture] //it is attribute,used to mark a class as a test fixture,class that contains one or more test methods.
    public class CustomerModelTests
    {
        [Test] //executes the methods within those classes that are marked 
        public void FirstName_Required()
        {
            // Arrange
            var customer = new CustomerModel
            {
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "+123456789",
                UserName = "johndoe",
                Password = "Password123",
                ConfirmPassword = "Password123"
            };

            // Act & Assert
            Assert.Throws<ValidationException>(() => ValidateModel(customer));
        }

        [Test]
        public void LastName_Required()
        {
            // Arrange
            var customer = new CustomerModel
            {
                FirstName = "John",
                Email = "john.doe@example.com",
                PhoneNumber = "+123456789",
                UserName = "johndoe",
                Password = "Password123",
                ConfirmPassword = "Password123"
            };

            // Act & Assert
            Assert.Throws<ValidationException>(() => ValidateModel(customer));
        }

        [Test]
        public void Email_Required()
        {
            // Arrange
            var customer = new CustomerModel
            {
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "+123456789",
                UserName = "johndoe",
                Password = "Password123",
                ConfirmPassword = "Password123"
            };

            // Act & Assert
            Assert.Throws<ValidationException>(() => ValidateModel(customer));
        }

        // Add more tests for other properties (e.g., PhoneNumber, UserName, Password, ConfirmPassword) following a similar pattern.

      
        [Test]
        public void Valid_Model()
        {
            // Arrange
            var customer = new CustomerModel
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                PhoneNumber = "+123456789",
                UserName = "johndoe",
                Password = "Password123",
                ConfirmPassword = "Password123"
            };

            // Act & Assert is for validation
            Assert.Throws<ValidationException>(() => ValidateModel(customer));
        }
        //ValidationContext for the model, and then calls ValidateModelAttributes to perform the validation.
        private void ValidateModel(CustomerModel model)
        {
            // for the provided CustomerModel (model). The ValidationContext is an object that encapsulates information
            // about the validation request.
            var validationContext = new ValidationContext(model, null, null);

            //ValidateModelAttributes method, passing the model and the validationContext, it is used for validate attribute
            var validationResults = ValidateModelAttributes(model, validationContext);

            //If there are any validation results (i.e., if the model is not valid according to the defined validation
            //attributes), it enters the conditional block.

            if (validationResults.Length > 0)
            {
                var errorMessages = validationResults.Select(result => result.ErrorMessage);
                var errorMessage = string.Join("\n", errorMessages);
  //It collects the error messages from the validation results and joins them into a single string using newline characters.
                throw new ValidationException(errorMessage);
            }
        }
        //It initializes an empty list, validationResults, to store the results of the validation.
        private ValidationResult[] ValidateModelAttributes(object model, ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults.ToArray();
        }
    }
}
// If any validation errors occur, the ValidateModel method throws a ValidationException containing the error messages.
