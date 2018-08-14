// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

#if IS_DESKTOP
using System;
using System.Reflection;

namespace NuGet.Protocol.Plugins
{
    public class MonoEmbeddedSignatureVerifier : EmbeddedSignatureVerifier
    {
        public override bool IsValid(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException(Strings.ArgumentCannotBeNullOrEmpty, nameof(filePath));
            }


            var assembly = Assembly.Load(
            "Mono.Security.dll, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");

            if (assembly == null)
            {
                return false;
            }
            var type = assembly.GetType("Mono.Security.Authenticode.AuthenticodeDeformatter");

            if (type == null)
            {
                return false;
            }

            var instance = Activator.CreateInstance(type, filePath);
            var method = type.GetMethod("IsTrusted");

            return (bool)method.Invoke(instance, null);
        }
    }
}
#endif
