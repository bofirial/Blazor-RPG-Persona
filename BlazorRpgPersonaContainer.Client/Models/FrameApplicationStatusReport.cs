using System;

namespace BlazorRpgPersonaContainer.Client.Models
{
    public class FrameApplicationStatusReport
    {
        public string FrameName { get; set; }

        public string Status { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}