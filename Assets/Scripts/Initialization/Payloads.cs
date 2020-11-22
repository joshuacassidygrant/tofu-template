using System;
using System.Collections.Generic;
using TofuCore.ResourceLibrary;
using TofuCore.ResourceModule;
using UnityEngine;

namespace Scripts.Content {
    public class Payloads : IContentList<Func<object, bool>> {
        public Dictionary<string, Func<object, bool>> Get() {
            return new Dictionary<string, Func<object, bool>>
            {
                {"Boolean", x => x is bool },
                {"Float", x => x is float },
                {"Integer", x => x is int },
                {"String", x => x is string },
                {"GameObject", x => x is GameObject },
                {"Vector3", x => x is Vector3 },
                {"Null", x => x == null},
                {"Transform", x => x is Transform },
                {"ResourceEventPayload", x => x is ResourceEventPayload},
                {"ResourceStateEventPayload", x => x is ResourceStateEventPayload },
            };
        }
    }
}

