using Phonebook;

namespace PhoneBookLibraryTests;

[TestFixture]
public class PhonebookTests
{
  private Phonebook.Phonebook phonebook;

  [OneTimeSetUp]
  public void OneTimeSetUp()
  {
    this.phonebook = new Phonebook.Phonebook();
  }

  [SetUp]
  public void SetUp()
  {
    this.phonebook = new Phonebook.Phonebook();
  }

  [OneTimeTearDown]
  public void OneTimeTearDown()
  {
    this.phonebook = null;
  }

  [Test]
  public void AddSubscribers_AddSubscribersSuccessfully()
  {
    //Arrange
    foreach (var subscriber in GetSubscribers())
    {
      phonebook.AddSubscriber(subscriber);
    }

    //Assert
    Assert.Multiple(() =>
    {
      Assert.NotNull(this.phonebook.GetAll());
      Assert.That(3, Is.EqualTo(this.phonebook.GetAll().Count()));
    });
  }

  [Test]
  public void AddSubscriber_ThrowException_SubscriberAlreadyExists()
  {
    //Arrange
    var subscriber = GetSubscribers()[0];

    //Act
    phonebook.AddSubscriber(subscriber);

    //Assert
    Assert.Throws<InvalidOperationException>(() => phonebook.AddSubscriber(subscriber));
  }

  [Test]
  public void AddSubscriber_ThrowException_PhoneNumberIsInvalid()
  {
    //Arrange
    var invalidPhoneNumber = new PhoneNumber("1234567890", PhoneNumberType.Personal);
    var subscriber = new Subscriber("Invalid User", new List<PhoneNumber> { invalidPhoneNumber });

    //Assert
    Assert.Throws<ArgumentException>(() => phonebook.AddSubscriber(subscriber), "Phone number is invalid");
  }

  [Test]
  public void GetSubscriber_ReturnCorrectSubscriberById()
  {
    //Arrange
    var subscribers = GetSubscribers();

    //Act
    foreach (var subscriber in subscribers)
    {
      phonebook.AddSubscriber(subscriber);
    }

    var subscriberToFind = subscribers[1];
    var foundSubscriber = phonebook.GetSubscriber(subscriberToFind.Id);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.NotNull(this.phonebook.GetAll());
      Assert.That(subscriberToFind, Is.EqualTo(foundSubscriber));
    });
  }

  [Test]
  public void RenameSubscriber_UpdateSubscriberName()
  {
    //Arrange
    var subscriber = GetSubscribers()[0];
    phonebook.AddSubscriber(subscriber);

    //Act
    phonebook.RenameSubscriber(subscriber, "New Name");

    //Assert
    var updatedSubscriber = phonebook.GetSubscriber(subscriber.Id);
    Assert.AreEqual("New Name", updatedSubscriber.Name);
  }

  [Test]
  public void AddNumberToSubscriber_AddedPhoneNumberToSubscriber()
  {
    //Arrange
    var subscriber = GetSubscribers()[0];
    phonebook.AddSubscriber(subscriber);
    var newPhoneNumber = new PhoneNumber("+8(111) 555-6666", PhoneNumberType.Work);

    //Act
    phonebook.AddNumberToSubscriber(subscriber, newPhoneNumber);

    //Assert
    var updatedSubscriber = phonebook.GetSubscriber(subscriber.Id);
    Assert.Contains(newPhoneNumber, updatedSubscriber.PhoneNumbers);
  }

  [Test]
  public void DeleteSubscriber_RemovedSubscriber()
  {
    //Arrange
    var subscribers = GetSubscribers();

    //Act
    foreach (var subscriber in subscribers)
    {
      phonebook.AddSubscriber(subscriber);
    }
    var subscriberToDelete = subscribers[0];
    phonebook.DeleteSubscriber(subscriberToDelete);

    //Assert
    Assert.Multiple(() =>
    {
      Assert.That(2, Is.EqualTo(phonebook.GetAll().Count()));
      Assert.IsFalse(phonebook.GetAll().Contains(subscriberToDelete));
    });
  }

  private List<Subscriber> GetSubscribers()
  {
    return new List<Subscriber>
    {
      new Subscriber("Tom", new List<PhoneNumber> { new PhoneNumber("+7(999)888-1234", PhoneNumberType.Personal) }),
      new Subscriber("Bob", new List<PhoneNumber> { new PhoneNumber("+7(988)333-0000", PhoneNumberType.Work) }),
      new Subscriber("Kek", new List<PhoneNumber> { new PhoneNumber("+7(955)444-9876", PhoneNumberType.Personal) })
    };
  }
}