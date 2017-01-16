using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordVerification;

namespace VerificationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InternalVerifyTestForPasswordFalse()
        {
            bool result = false;
            Verification v = Construct();
            Verification.Internal i = new Verification.Internal();
            Assert.AreEqual(result, v.Verify("dH1",i), "error");
           
        }

        [TestMethod]
        public void InternalVerifyTestForPasswordTrue()
        {
            bool result = true;
            Verification v = Construct();
            Verification.Internal i = new Verification.Internal();

            Assert.AreEqual(result, v.Verify("dhanya123456", i), "error");

        }

        private static Verification Construct()
        {
            return new Verification();
        }


        [TestMethod]
        public void ExternalVerificationTestForNull()
        {

            //  PasswordValidator.Verify("");
            try
            {
                Verification v = Construct();
                Verification.External e = new Verification.External();
                v.Verify("",e);
            }
            catch (ValidationException e)
            {
                Assert.AreEqual("Password can't be empty", e.Message, "error");
            }

        }
        [TestMethod]
        public void ExternalVerificationTestForUpperCase()
        {

            try
            {
               // Verification.VerifyUpper("dsfgjhdsfjk");
                Verification v = Construct();
                Verification.External e = new Verification.External();
                v.Verify("dsfgjhdsfjk", e);
            }
            catch (ValidationException e)
            {
                Assert.AreEqual("Password should have at least one upper case letter", e.Message, "error");
            }


        }
        [TestMethod]
        public void ExternalVerificationTestForLowerCase()
        {
            try
            {
                //Verification.VerifyLower("SGFKSGFUK");
                Verification v = Construct();
                Verification.External e = new Verification.External();
                //string s = null;
                string s = "";
                v.Verify("GFKSGFUK", e);

            }
            catch (ValidationException e)
            {
                Assert.AreEqual("Password should have at least one Lower case letter", e.Message, "error");
            }

        }

        [TestMethod]
        public void ExternalVerificationTestForNumber()
        {
            try
            {
                //Verification.VerifyNumber("fvgkysdAFE");
                Verification v = Construct();
                Verification.External e = new Verification.External();
                v.Verify("fvgkysdAFE", e);
            }
            catch (ValidationException e)
            {
                Assert.AreEqual("Password should have at least one number", e.Message, "error");
            }

        }
        [TestMethod]
        public void ExternalVerificationTestForLength()
        {
            try
            {
               // Verification.VerifyLength("fvVk1");
                Verification v = Construct();
                Verification.External e = new Verification.External();
                v.Verify("fvVk1", e);
            }
            catch (ValidationException e)
            {
                Assert.AreEqual("password should have minimum of 8 charcaters", e.Message, "error");
            }

        }
        [TestMethod]
        public void ExternalVerificationVerifyTestForPasswordFalse()
        {
            bool result = false;
            Verification v = Construct();
            Verification.External e = new Verification.External();
            //v.Verify("fvVk1", e);
            Assert.AreEqual(result, v.Verify("dha",e), "error");
        }
        [TestMethod]
        public void ExternalVerificationVerifyTestForPasswordTrue()
        {
            bool result = true;
            Verification v = Construct();
            Verification.External e = new Verification.External();
            //v.Verify("fvVk1", e);
            Assert.AreEqual(result, v.Verify("dhaA", e), "error");
        }

        [TestMethod]
        public void ExternalVerificationVerifyTestForPasswordTrueAllCondition()
        {
            bool result = true;
            Verification v = Construct();
            Verification.External e = new Verification.External();
            //v.Verify("fvVk1", e);
            Assert.AreEqual(result, v.Verify("dhaA1asgsd", e), "error");
        }

    }

}
