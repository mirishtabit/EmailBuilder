using EmailBuilder.Common;
using EmailBuilder.Models.Properties;

namespace EmailBuilder.Models.Configurations.SubConfiguration
{
    public class DefaultGeneralStyles
    {
        public double LineHeight { get; set; }
        public Direction WritingDirection { get; set; }


        public string GenerateCssStyles()
        {
            string directionStyle = WritingDirection != Direction.Parent ? $"direction:{WritingDirection.ToString().ToLower()};" : string.Empty;
            return $@"
            * {{
                line-height:{LineHeight};
                {directionStyle};
            }}";
        }
    }
}
