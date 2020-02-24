using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banking;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ID_1_TestMethod_IsAccountNumberVerified_BVAValid_AccountNumberMin()
        {
            //Arrange
            long accountNumber = 32000000; //Minimum account Number
            bool expected = true;
            
            //Act
            BankAccount bank = new BankAccount(290,"Kiranjeet");
            bool actual = bank.IsAccountNumberVerified(accountNumber);

            //ASSERT
            Assert.AreEqual(actual, expected,"Account Number verification test failed");
        }

        [TestMethod]
        public void ID_2_TestMethod_IsAccountNumberVerified_BVAValid_AccountNumberMinPlus1()
        {
            //Arrange
            long accountNumber = 32000001; //Minimum + 1 Account Number
            bool expected = true;

            //Act
            BankAccount bank = new BankAccount(300, "Kiranjeet");
            bool actual = bank.IsAccountNumberVerified(accountNumber);

            //ASSERT
            Assert.AreEqual(actual, expected, "Account Number verification test failed");
        }

        [TestMethod]
        public void ID_3_TestMethod_IsAccountNumberVerified_BVAValid_AccountNumberMaxMinus1()
        {
            //Arrange
            long accountNumber = 32999998; //Maximum - 1 Account number
            bool expected = true;

            //Act
            BankAccount bank = new BankAccount(417, "Kiranjeet");
            bool actual = bank.IsAccountNumberVerified(accountNumber);

            //ASSERT
            Assert.AreEqual(actual, expected, "Account Number verification test failed");
        }

        [TestMethod]
        public void ID_4_TestMethod_IsAccountNumberVerified_BVAValid_AccountNumberMax()
        {
            //Arrange
            long accountNumber = 32999999; //Maximum account number
            bool expected = true;

            //Act
            BankAccount bank = new BankAccount(500, "Kiranjeet");
            bool actual = bank.IsAccountNumberVerified(accountNumber);

            //ASSERT
            Assert.AreEqual(actual, expected, "Account Number verification test failed");
        }

        [TestMethod]
        public void ID_5_TestMethod_IsAccountNumberVerified_Invalid_AccountNumberPolicyA()
        {
            //Arrange
            long accountNumber = 320000010; //9 digits account number
            String expected = BankAccount.WRONG_ACCOUNT_NUMBER;

            //Act
            BankAccount bank = new BankAccount(410,"Kiranjeet");

            try
            {
                bank.IsAccountNumberVerified(accountNumber);

            }

            //Assert
            catch (Exception ex)
            {
                String actual = ex.Message;

                // Test passed if this assert is true
                StringAssert.Contains(actual, expected);

                // Add return to finish the test.
                return;
            }

            // The test fails if an exception is not thorn.
            Assert.Fail("Account Number verification test failed - no exception was thrown.");
        }

        [TestMethod]
        public void ID_6_TestMethod_IsAccountNumberVerified_Invalid_AccountNumberPolicyB()
        {
            //Arrange
            long accountNumber = 30000001; //Account number not starting with 32
            String expected = BankAccount.WRONG_ACCOUNT_NUMBER;

            //Act
            BankAccount bank = new BankAccount(200, "Kiranjeet");

            try
            {
                bank.IsAccountNumberVerified(accountNumber);

            }

            //Assert
            catch (Exception ex)
            {
                String actual = ex.Message;

                // Test passed if this assert is true
                StringAssert.Contains(actual, expected);

                // Add return to finish the test.
                return;
            }

            // The test fails if an exception is not thorn.
            Assert.Fail("Account Number verification test failed - no exception was thrown.");
        }

        [TestMethod]
        public void ID_7_TestMethod_IsAccountNumberVerified_BVAInvalid_AccountNumberLowerEnd()
        {
            //Arrange
            long accountNumber = 31999999;
            String expected = BankAccount.WRONG_ACCOUNT_NUMBER;

            //Act
            BankAccount bank = new BankAccount(10, "Kiranjeet");

            try
            {
                bank.IsAccountNumberVerified(accountNumber);

            }

            //Assert
            catch (Exception ex)
            {
                String actual = ex.Message;

                // Test passed if this assert is true
                StringAssert.Contains(actual, expected);

                // Add return to finish the test.
                return;
            }

            // The test fails if an exception is not thorn.
            Assert.Fail("Account Number verification test failed - no exception was thrown.");
        }

        [TestMethod]
        public void ID_8_TestMethod_IsAccountNumberVerified_BVAInvalid_AccountNumberUpperEnd()
        {
            //Arrange
            long accountNumber = 33000000;
            String expected = BankAccount.WRONG_ACCOUNT_NUMBER;

            //Act
            BankAccount bank = new BankAccount(85, "Kiranjeet");

            try
            {
                bank.IsAccountNumberVerified(accountNumber);

            }

            //Assert
            catch (Exception ex)
            {
                String actual = ex.Message;

                // Test passed if this assert is true
                StringAssert.Contains(actual, expected);

                // Add return to finish the test.
                return;
            }

            // The test fails if an exception is not thorn.
            Assert.Fail("Account Number verification test failed - no exception was thrown.");
        }

        [TestMethod]
        public void ID_9_TestMethod_UpdateAcountHolderName_ValidName()
        {
            //This test verifies whether the banking class assigns name correctly

            //Arrange
            String Name = "Kiranjeet";
            String expected = Name;

            //Act
            BankAccount bank = new BankAccount(20,"Manpreet");
            bank.UpdateAccountHolderName(Name);
            String actual = bank.AccountHolderName;

            //Assert
            StringAssert.Contains(expected, actual,"Account Holder Name test failed");
          }

        [TestMethod]
        public void ID_10_TestMethod_Deposit_BVAValid_DepositMin()
        {
            //Arrange
            double balance = 200;
            double deposit_amount = 0.1;
            double expected = balance + deposit_amount;

            //Act
            BankAccount bank = new BankAccount(balance,"Kiranjeet");
            bank.Deposit(deposit_amount);
            double actual = bank.Balance;

            //Assert
            Assert.AreEqual(expected, actual, 0, "Deposit test failed");

        }

        [TestMethod]
        public void ID_11_TestMethod_Deposit_BVAValid_DepositMinPlus1()
        {
            //Arrange
            double balance = 200;
            double deposit_amount = 1.1;
            double expected = balance + deposit_amount;

            //Act
            BankAccount bank = new BankAccount(balance, "Kiranjeet");
            bank.Deposit(deposit_amount);
            double actual = bank.Balance;

            //Assert
            Assert.AreEqual(expected, actual, 0, "Deposit test failed");
        }

        [TestMethod]
        public void ID_12_TestMethod_Deposit_BVAInvalid_DepositZero()
        {
            //Arrange
            String expected = BankAccount.WRONG_AMOUNT;

            //Act
            BankAccount bank = new BankAccount(200, "Kiranjeet");

            try
            {
                bank.Deposit(0);

            }

            //Assert
            catch (Exception ex)
            {
                String actual = ex.Message;

                // Test passed if this assert is true
                StringAssert.Contains(actual, expected);

                // Add return to finish the test.
                return;

            }

            // The test fails if an exception is not thorn.
            Assert.Fail("Deposit test failed - no exception was thrown.");
        }

        [TestMethod]
        public void ID_13_TestMethod_Deposit_BVAInvalid_DepositNegative()
        {
            //Arrange
            String expected = BankAccount.WRONG_AMOUNT;

            //Act
            BankAccount bank = new BankAccount(200, "Kiranjeet");

            try
            {
                bank.Deposit(-3);

            }

            //Assert
            catch (Exception ex)
            {
                String actual = ex.Message;

                // Test passed if this assert is true
                StringAssert.Contains(actual, expected);

                // Add return to finish the test.
                return;
            }

            // The test fails if an exception is not thorn.
            Assert.Fail("Deposit test failed - no exception was thrown.");
        }

        [TestMethod]
        public void ID_14_TestMethod_Debit_ValidDebit()
        {
            //This test verifies whether the banking class perform debit correctly for valid input
            //Arrange
            double balance = 200;
            double debitted_amount = 30;            
            double expected_debitted_amount = debitted_amount;
            double expexted_balance = balance - debitted_amount;

            //Act
            BankAccount bank = new BankAccount(balance, "Kiranjeet");
            bank.Debit(debitted_amount);
            double actual_balance = bank.Balance;
            double actual_debitted_amount = balance - bank.Balance;

            //Assert
            Assert.AreEqual(expected_debitted_amount , actual_debitted_amount, 0, "Debit test failed - Difference in debitted amount");
            Assert.AreEqual(expexted_balance, actual_balance, 0, "Debit test failed - Difference in balance ");
        }

        [TestMethod]
        public void ID_15_TestMethod_Debit_BVAInvalid_Debit_Zero()
        {
            //Arrange
            String expected = BankAccount.WRONG_AMOUNT;

            //Act
            BankAccount bank = new BankAccount(200, "Kiranjeet");

            try
            {
                bank.Debit(0);

            }

            //Assert
            catch (Exception ex)
            {
                String actual = ex.Message;

                // Test passed if this assert is true
                StringAssert.Contains(actual, expected);

                // Add return to finish the test.
                return;

            }

            // The test fails if an exception is not thorn.
            Assert.Fail("Debit test failed - no exception was thrown.");
        }

        [TestMethod]
        public void ID_16_TestMethod_Debit_BVAInvalidDebitNegative()
        {
            //Arrange
            String expected = BankAccount.WRONG_AMOUNT;

            //Act
            BankAccount bank = new BankAccount(200, "Kiranjeet");

            try
            {
                bank.Debit(-3);

            }

            //Assert
            catch (Exception ex)
            {
                String actual = ex.Message;

                // Test passed if this assert is true
                StringAssert.Contains(actual, expected);

                // Add return to finish the test.
                return;
            }

            // The test fails if an exception is not thorn.
            Assert.Fail("Debit test failed - no exception was thrown.");
        }

        [TestMethod]
        public void ID_17_TestMethod_Debit_InvalidDebitInsufficientBalance()
        {
            //Arrange
            String expected = BankAccount.INSUFFICIENT_BALANCE;

            //Act
            BankAccount bank = new BankAccount(200, "Kiranjeet");

            try
            {
                //Debitting amount is more than the balance
                bank.Debit(250);
            }

            //Assert
            catch (Exception ex)
            {
                String actual = ex.Message;

                // Test passed if this assert is true
                StringAssert.Contains(actual, expected);

                // Add return to finish the test.
                return;
            }

            // The test fails if an exception is not thorn.
            Assert.Fail("Debit test failed - no exception was thrown.");
        }
    }
}
