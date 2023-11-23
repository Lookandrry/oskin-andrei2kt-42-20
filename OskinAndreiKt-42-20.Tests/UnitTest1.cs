
using OskinAndreiKt_42_20.Models;

namespace OskinAndreiKt_42_20.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void IsValidMail_True()
        {
            var MailTest = new Prepod
            {
                Mail = "mm@mail.ru"
            };

            var result = MailTest.IsValidMail();

            Assert.False(result);

        }
    }
}