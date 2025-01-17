using System.Collections.Generic;
using Newtonsoft.Json;
using TimberApi.SpecificationSystem;
using TimberApi.SpecificationSystem.SpecificationTypes;
using Timberborn.PrioritySystem;

namespace TimberApi.ToolSystem.Tools.BuilderPriority
{
    public class BuilderPriorityToolGenerator : ISpecificationGenerator
    {
        public IEnumerable<ISpecification> Generate()
        {
            foreach (var priority in Priorities.Ascending)
            {
                var json = JsonConvert.SerializeObject(new
                {
                    Id = priority,
                    GroupId = "Priority",
                    Type = "PriorityTool",
                    Layout = "Default",
                    Order = (int) priority,
                    Icon = $"Sprites/Priority/Buttons/{priority}",
                    NameLocKey = "CAN NOT BE MODIFIED",
                    DescriptionLocKey = "CAN NOT BE MODIFIED",
                    Hidden = false,
                    DevMode = false,
                    ToolInformation = new
                    {
                        Priority = priority
                    }
                });

                yield return new GeneratedSpecification(json, priority.ToString(), "ToolSpecification");
            }

            yield return CreatePriorityToolGroup();
        }

        private static GeneratedSpecification CreatePriorityToolGroup()
        {
            var json = JsonConvert.SerializeObject(new
            {
                Id = "Priority",
                Layout = "Blue",
                Order = 50,
                Type = "DefaultToolGroup",
                NameLocKey = "ToolGroups.Priority",
                Icon = "Sprites/BottomBar/PriorityToolGroupIcon",
                Section = "BottomBar",
                DevMode = false,
                Hidden = false,
                FallbackGroup = false,
                GroupInformation = new
                {
                    BottomBarSection = 0
                }
            });

            return new GeneratedSpecification(json, "Priority", "ToolGroupSpecification");
        }
    }
}