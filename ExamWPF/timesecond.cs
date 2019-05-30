﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWPF
{
  public class timesecond : DateTimeConverterBase
  {
    private static readonly DateTime _epoch = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      writer.WriteRawValue(((DateTime)value - _epoch).TotalMilliseconds + "000");
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
      if (reader.Value == null) { return null; }
      return _epoch.AddMilliseconds((long)reader.Value / 1000d);
    }
  }
}
