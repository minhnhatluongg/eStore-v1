using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace OA.Core.Constants
{
    public static class ResponseResultHelper
    {
        public static void MakeException(ResponseResult result, Exception ex)
        {
            result.Success = false;
            result.Message = Utilities.MakeExceptionMessage(ex);
        }

        public static void MakeFailure(ResponseResult result, string message = null, int? errorNumber = null)
        {
            result.Success = false;
            result.Message = message;
        }

        public static void MakeSuccess(ResponseResult result, string message = null)
        {
            result.Success = true;
            result.Message = message;
        }
    }
}
