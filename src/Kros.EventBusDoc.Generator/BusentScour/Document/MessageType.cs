﻿using System;

namespace Kros.EventBusDoc.Generator.BusentScour.Document
{
    [Flags]
    public enum MessageType
    {
        None = 0,
        @Event = 1,
        @Command = 2,
        Saga = 4
    }
}