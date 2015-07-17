﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FirebaseSharp.Portable.Interfaces;
using FirebaseSharp.Portable.Subscriptions;
using Newtonsoft.Json.Linq;

namespace FirebaseSharp.Portable.Filters
{
    class OrderByChildFilter : ISubscriptionFilter
    {
        private readonly string _child;

        public OrderByChildFilter(string child)
        {
            _child = child;
        }

        public JToken Apply(JToken filtered)
        {
            throw new NotImplementedException();
        }
    }
}
