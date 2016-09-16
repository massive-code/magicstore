using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace magicstore.Models
{
    public class cl_Information
    {
        public String Information(String s_Data)
        {
            String s_Info = String.Empty;
            switch (s_Data)
            {
                case "sign_in_failed": s_Info = "Неверный логин или пароль"; break;
                case "sign_in_success": s_Info = "Авторизация - Успешно"; break;
                case "sign_out_success":s_Info = "Выход - Успешно "; break;
                case "sign_out_failed":s_Info = "Выход - Неверные данные"; break;
                case "registration_success": s_Info = "Регистрация - Успешно"; break;
                case "registration_failed": s_Info = "Регистрация - Пользователь с таким логином и/или email уже существует"; break;
                    
            }
            return s_Info;
        }
    }
}