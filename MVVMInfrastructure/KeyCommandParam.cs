using System;
using System.Collections.Generic;

namespace MVVMInfrastructure
{
    public class KeyCommandParam
    {
        private readonly Key _key;

        public KeyCommandParam(Key key)
        {
            _key = key;
        }

        public Key Key => _key;
    }
}
