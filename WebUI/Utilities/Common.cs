using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Utilities
{
    public class Common
    {
        //解密连接字符串
        public string connstr()
        {
            string conn;
            conn = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(System.Configuration.ConfigurationManager.ConnectionStrings["EFpp"].ConnectionString));
            return conn;
        }
        //前端表Json数据传到实体类
        public T getitem<T>(T t1, JObject t2, string idstr)
        {
            foreach (System.Reflection.PropertyInfo info in t1.GetType().GetProperties())
            {
                if (info.Name != idstr)
                {
                    //object keyval = t2.GetType().GetProperty(info.Name).GetValue(t2, null);
                    JToken keyval = t2.SelectToken(info.Name);
                    if (null != keyval && ""!= keyval.ToString())
                    {
                        Type baseType;
                        if (info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            Type[] typeArray = info.PropertyType.GetGenericArguments();
                            baseType = typeArray[0];
                        }
                        else
                        {
                            baseType = info.PropertyType;
                        }

                        switch (baseType.Name)
                        {

                            case "DateTime":
                                info.SetValue(t1, Convert.ToDateTime(keyval));
                                break;
                            case "String":
                                info.SetValue(t1, Convert.ToString(keyval));
                                break;
                            case "Decimal":
                                info.SetValue(t1, Convert.ToDecimal(keyval));
                                break;
                            case "Int32":
                                info.SetValue(t1, Convert.ToInt32(keyval));
                                break;
                            case "Int16":
                                info.SetValue(t1, Convert.ToInt16(keyval));
                                break;
                            case "short":
                                info.SetValue(t1, Convert.ToInt16(keyval));
                                break;
                            case "Byte":
                                info.SetValue(t1, Convert.ToByte(keyval));
                                break;
                            case "Boolean":
                                info.SetValue(t1, Convert.ToBoolean(Convert.ToInt32(keyval)));
                                break;
                            default:
                                break;

                        }
                    }
                }

            }
            return (T)(Object)t1;
        }
        //前端表HttpContext数据传到实体类
        public T getitemform<T>(T t1, HttpContext t2, string idstr)
        {
            foreach (System.Reflection.PropertyInfo info in t1.GetType().GetProperties())
            {
                if (info.Name != idstr)
                {
                    string keyval= t2.Request[info.Name];
                    if (!string.IsNullOrEmpty(keyval))
                    {
                        Type baseType;
                        if (info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        {
                            Type[] typeArray = info.PropertyType.GetGenericArguments();
                            baseType = typeArray[0];
                        }
                        else
                        {
                            baseType = info.PropertyType;
                        }

                        switch (baseType.Name)
                        {

                            case "DateTime":
                                info.SetValue(t1, Convert.ToDateTime(keyval));
                                break;
                            case "String":
                                info.SetValue(t1, (string)keyval);
                                break;
                            case "Decimal":
                                info.SetValue(t1, Convert.ToDecimal(keyval));
                                break;
                            case "Int32":
                                info.SetValue(t1, Convert.ToInt32(keyval));
                                break;
                            case "Int16":
                                info.SetValue(t1, Convert.ToInt16(keyval));
                                break;
                            case "short":
                                info.SetValue(t1, Convert.ToInt16(keyval));
                                break;
                            case "Byte":
                                info.SetValue(t1, Convert.ToByte(keyval));
                                break;
                            case "Boolean":
                                info.SetValue(t1, Convert.ToBoolean(Convert.ToInt32(keyval)));
                                break;
                            default:
                                break;

                        }

                    }
                }
            }
            return (T)(Object)t1;
        }
        public T getitem1<T>(T t1, JObject t2, string idstr)
        {
            foreach (var key in t2)
            {
                if (key.Key != idstr)
                {
                    foreach (System.Reflection.PropertyInfo info in t1.GetType().GetProperties())
                    {
                        if (info.Name == key.Key)
                        {
                            if (key.Key == idstr || string.IsNullOrEmpty(key.Value.ToObject<string>())) { }
                            else
                            {
                                Type baseType;
                                if (info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                {
                                    Type[] typeArray = info.PropertyType.GetGenericArguments();
                                    baseType = typeArray[0];
                                }
                                else
                                {
                                    baseType = info.PropertyType;
                                }

                                switch (baseType.Name)
                                {

                                    case "DateTime":
                                        info.SetValue(t1, (DateTime)key.Value);
                                        break;
                                    case "String":
                                        info.SetValue(t1, (string)key.Value);
                                        break;
                                    case "Decimal":
                                        info.SetValue(t1, (Decimal)key.Value);
                                        break;
                                    case "Int32":
                                        info.SetValue(t1, (int)key.Value);
                                        break;
                                    case "Int16":
                                        info.SetValue(t1, (short)key.Value);
                                        break;
                                    case "short":
                                        info.SetValue(t1, (short)key.Value);
                                        break;
                                    case "Byte":
                                        info.SetValue(t1, (Byte)key.Value);
                                        break;
                                    case "Boolean":
                                        info.SetValue(t1, Convert.ToBoolean((int)key.Value));
                                        break;
                                    default:
                                        break;

                                }
                            }

                        }
                    }
                }
            }
            return (T)(Object)t1;
        }
        public T getitemform1<T>(T t1, HttpContext t2, string idstr)
        {
            foreach (var key in t2.Request.Params.AllKeys)
            {
                if (key != idstr)
                {
                    foreach (System.Reflection.PropertyInfo info in t1.GetType().GetProperties())
                    {
                        string keyval = t2.Request[key];
                        if (info.Name == key)
                        {
                            if (key == idstr || string.IsNullOrEmpty(keyval)) { }
                            else
                            {
                                Type baseType;
                                if (info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                {
                                    Type[] typeArray = info.PropertyType.GetGenericArguments();
                                    baseType = typeArray[0];
                                }
                                else
                                {
                                    baseType = info.PropertyType;
                                }

                                switch (baseType.Name)
                                {

                                    case "DateTime":
                                        info.SetValue(t1, Convert.ToDateTime(keyval));
                                        break;
                                    case "String":
                                        info.SetValue(t1, (string)keyval);
                                        break;
                                    case "Decimal":
                                        info.SetValue(t1, Convert.ToDecimal(keyval));
                                        break;
                                    case "Int32":
                                        info.SetValue(t1, Convert.ToInt32(keyval));
                                        break;
                                    case "Int16":
                                        info.SetValue(t1, Convert.ToInt16(keyval));
                                        break;
                                    case "short":
                                        info.SetValue(t1, Convert.ToInt16(keyval));
                                        break;
                                    case "Boolean":
                                        info.SetValue(t1, Convert.ToBoolean(Convert.ToInt32(keyval)));
                                        break;
                                    default:
                                        break;

                                }
                            }

                        }
                    }
                }
            }
            return (T)(Object)t1;
        }

    }
}