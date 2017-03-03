using System.Collections.Generic;

using ProstoA.Data.Metamodel;
using ProstoA.Data.Model.Abstractions;

namespace ProstoA.Workflow {
    public interface IWorkflowTransition : IDisplayModel {
        IObjectIdentity Name { get; }

        IObjectValue Data { get; }

        IEnumerable<IWorkflowState> NextStates { get; }
    }
}