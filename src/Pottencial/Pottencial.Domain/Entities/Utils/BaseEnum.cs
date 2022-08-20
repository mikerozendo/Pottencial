﻿using System.Reflection;
using System.ComponentModel;

namespace Pottencial.Domain.Entities.Utils;

public class BaseEnum<EnumType>
{
    public static string GetDescription(EnumType value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(
            typeof(DescriptionAttribute),
            false);

        if (attributes != null &&
            attributes.Length > 0)
            return attributes[0].Description;
        else
            return value.ToString();
    }
}