// Copyright (C) Microsoft Corporation. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Reflection;
using System;

namespace WebView2WpfBrowser
{
    // BridgeAddRemoteObject is a .NET object that implements IDispatch and works with AddRemoteObject.
    // See the AddRemoteObjectCmdExecute method that demonstrates how to use it from JavaScript.
#pragma warning disable CS0618
    // The.NET version of CoreWebView2.AddHostObjectToScript currently relies on the host object
    // implementing IDispatch and so uses the deprecated ClassInterfaceType.AutoDual feature of.NET.
    // This may change in the future, please see https://github.com/MicrosoftEdge/WebView2Feedback/issues/517  for more information
   [ClassInterface(ClassInterfaceType.AutoDual)]
#pragma warning restore CS0618
    [ComVisible(true)]
    public class AnotherRemoteObject
    {

        // Sample property.
        public string Prop { get; set; } = "AnotherRemoteObject.Prop";
    }

#pragma warning disable CS0618
    [ClassInterface(ClassInterfaceType.AutoDual)]
#pragma warning restore CS0618
    [ComVisible(true)]
    public class BridgeAddRemoteObject
    {
        // Sample function that takes a parameter.
        public string Func(string param)
        {
            return "BridgeAddRemoteObject.Func(" + param + ")";
        }

        // Sample function that takes no parameters.
        public string Func2()
        {
            return "BridgeAddRemoteObject.Func2()";
        }

        // Get type of an object.
        public string GetObjectType(object obj)
        {
            return obj.GetType().Name;
        }

        // Sample property.
        public string Prop { get; set; } = "BridgeAddRemoteObject.Prop";

        public DateTime DateProp { get; set; } = DateTime.UtcNow;

        public AnotherRemoteObject AnotherObject { get; set; } = new AnotherRemoteObject();

        // Sample indexed property.
        [System.Runtime.CompilerServices.IndexerName("Items")]
        public string this[int index]
        {
            get { return m_dictionary[index]; }
            set { m_dictionary[index] = value; }
        }
        private Dictionary<int, string> m_dictionary = new Dictionary<int, string>();

    }
}
