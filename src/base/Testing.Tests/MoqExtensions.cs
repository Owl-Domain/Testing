using System;

namespace Testing.Tests;

internal static class MoqExtensions
{
   #region Methods
   public static void VerifyFailFormat(this Mock<IAssert> mock, Func<Times> times)
   {
      mock.Verify(
         a =>
            a.Fail(
               It.IsAny<string>(),
               It.IsAny<object?[]>()),
         times);
   }
   #endregion
}
