﻿using System;
using System.Collections.Generic;

namespace Kros.EventBusDoc.Generator.Middleware
{
    public class EventBusDocOptions
    {
        public string RouteTemplate { get; set; } = "busent/{documentName}/busent.json";

        public IEnumerable<Type> IgnoreTypeList { get; set; } = new List<Type>();
    }
}