using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace AzureFunctionsOpenAPIDemo.ViewModel
{
    /// <summary>
    /// A pet ViewModel for upload image form post
    /// </summary>
    public class PetUploadFileForm
    {
        /// <summary>
        /// Additional data to pass to server
        /// </summary>
        [Required]
        [DataMember(Name = "additionalMetadata")]
        public string AdditionalMetadata { get; set; }

        /// <summary>
        /// file to upload
        /// </summary>
        [DataMember(Name = "file")]
        public System.IO.Stream File { get; set; }
    }
}
