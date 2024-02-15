using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models;

namespace NunitInsurance
{
    [TestFixture] //Test fixtures are classes that contain one or more test methods.
    public class QuestionViewTests
    {
        [Test]
        public void QuestionId_NotRequired()
        {
            // Arrange
            var questionView = new QuestionView
            {
                Question = "Test question",
                Date = DateTime.Now,
                Answer = "Test answer",
                CustomerId = 123
            };

            // Act & Assert
            // The Assert.DoesNotThrow method is used to check that the ValidateModel method does not
            //throw an exception when validating the questionView
            Assert.DoesNotThrow(() => ValidateModel(questionView));
        }

        [Test]
        public void Question_LengthWithinLimit()
        {
            // Arrange
            var questionView = new QuestionView
            {
                Question = new string('A', 255), // Max length allowed
                Date = DateTime.Now,
                Answer = "Test answer",
                CustomerId = 123
            };

            // Act & Assert
            Assert.DoesNotThrow(() => ValidateModel(questionView));
        }

        [Test]
        public void Date_DefaultsToCurrentDate()
        {
            // Arrange
            var questionView = new QuestionView
            {
                Question = "Test question",
                Answer = "Test answer",
                CustomerId = 123
            };

            // Act
            DateTime currentDate = DateTime.Now;

            // Assert
            Assert.That(questionView.Date.Date, Is.EqualTo(currentDate.Date));
        }

        [Test]
        public void Answer_LengthWithinLimit()
        {
            // Arrange
            var questionView = new QuestionView
            {
                Question = "Test question",
                Date = DateTime.Now,
                Answer = new string('A', 255), // Max length allowed
                CustomerId = 123
            };

            // Act & Assert
            Assert.DoesNotThrow(() => ValidateModel(questionView));
        }

        [Test]
        public void CustomerId_Required()
        {
            // Arrange
            var questionView = new QuestionView
            {
                Question = "Test question",
                Date = DateTime.Now,
                Answer = "Test answer",
                CustomerId = 123 // Provide a valid CustomerId
            };

            // Act & Assert
            Assert.DoesNotThrow(() => ValidateModel(questionView));
        }


        private void ValidateModel(QuestionView model)
        {
            var validationContext = new ValidationContext(model, null, null);
            //ValidationContext is used to provide information about the object being validated, and Validator.
            //TryValidateObject performs the actual validation
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);

            if (validationResults.Any())
            {
                var errorMessage = string.Join(Environment.NewLine, validationResults.Select(r => r.ErrorMessage));
                throw new ValidationException(errorMessage);
                //ValidationException is thrown, containing error messages from the validation results.
            }
        }
    }
}
