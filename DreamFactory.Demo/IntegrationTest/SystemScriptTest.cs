﻿namespace DreamFactory.Demo.IntegrationTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamFactory.Api;
    using DreamFactory.Model.System.Script;
    using DreamFactory.Rest;

    public class SystemScriptTest
    {
        private const string ScriptId = "dummybear";

        // ReSharper disable PossibleMultipleEnumeration
        public static async Task RunTest(IRestContext context)
        {
            ISystemApi systemApi = context.Factory.CreateSystemApi();

            IEnumerable<ScriptResponse> scripts = await systemApi.GetScriptsAsync(true);
            Console.WriteLine("GetScriptsAsync(): {0}", scripts.Select(x => x.script_id).ToStringList());

            if (scripts.Any(x => x.script_id == ScriptId))
            {
                await DeleteDummyScript(systemApi);
            }

            const string scriptText = @"return Number(event.n1) + Number(event.n2);";
            ScriptResponse response = await systemApi.WriteScriptAsync(ScriptId, scriptText);
            Console.WriteLine("WriteScriptAsync(): id={0}", response.script_id);

            Dictionary<string, object> p = new Dictionary<string, object> { { "n1", 3 }, { "n2", 5 } };
            string output = await systemApi.RunScriptAsync(ScriptId, p);
            Console.WriteLine("RunScriptAsync(): {0}", context.ContentSerializer.Serialize(output));

            await DeleteDummyScript(systemApi);
        }

        private static async Task DeleteDummyScript(ISystemApi systemApi)
        {
            await systemApi.DeleteScriptAsync(ScriptId);
            Console.WriteLine("DeleteScriptAsync({0})", ScriptId);
        }
    }
}