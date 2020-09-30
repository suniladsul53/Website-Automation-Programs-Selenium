using G1ANT.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1ANT.Addon.Reddit
{
    [Command(Name = "reddit.logout", Tooltip = "This command logout from the reddit account.")]
    public class RedditLogoutCommand : Command
    {
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public RedditLogoutCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                arguments.Search.Value = "/html/body/div[1]/div/div[2]/div[2]/div/div/div/div[2]/div[2]";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);

                arguments.Search.Value = "provide xpath here";
                arguments.By.Value = "xpath";
                SeleniumManager.CurrentWrapper.Click(arguments, arguments.Timeout.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while closing selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}