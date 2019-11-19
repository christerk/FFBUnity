using System;

namespace Fumbbl.Dto.Reports
{
    internal class ProtocolIdAttribute : Attribute
    {
        public string ProtocolKey { get; }

        public ProtocolIdAttribute(string protocolKey)
        {
            ProtocolKey = protocolKey;
        }
    }
}