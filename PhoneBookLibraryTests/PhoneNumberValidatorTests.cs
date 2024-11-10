using Phonebook;

namespace PhoneBookLibraryTests;

[TestFixture]
public class PhoneNumberValidatorTests
{
  [Test]
  public void Validate_NotThrowException_ValidPhoneNumber()
  {
    //Arrange
    var validPhoneNumber = new PhoneNumber("+7(123)456-7890", PhoneNumberType.Personal);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.NotNull(validPhoneNumber);
      Assert.DoesNotThrow(() => PhoneNumberValidator.Validate(validPhoneNumber));
    });
  }

  [Test]
  public void Validate_ThrowException_IncorrectPhoneNumber()
  {
    //Arrange
    var invalidPhoneNumber = new PhoneNumber("12345", PhoneNumberType.Personal);

    //Assert
    Assert.Throws<ArgumentException>(() => PhoneNumberValidator.Validate(invalidPhoneNumber));
  }
}
