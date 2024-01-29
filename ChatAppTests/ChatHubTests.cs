using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppTests
{
    internal class ChatHubTests
    {
        [Test]
        public void ChatHubIsTrue()
        {
            bool isTrue = true;
            Assert.That(isTrue, Is.True);
        }
    }
}
