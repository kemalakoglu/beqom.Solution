﻿using System.Runtime.Serialization;

namespace beqom.Core.Extension
{
    [DataContract]
    public class ResponseDTO<T> where T : class
    {
        [DataMember]
        public T Data { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public Information Information { get; set; }
        [DataMember]
        public string RC { get; set; }
    }

    [DataContract]
    public class Information
    {
        [DataMember]
        public string TrackId { get; set; }
    }
}
