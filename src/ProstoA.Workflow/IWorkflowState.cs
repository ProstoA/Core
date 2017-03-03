using System.Collections.Generic;

using ProstoA.Data.Metamodel;
using ProstoA.Data.Model.Abstractions;

namespace ProstoA.Workflow {
    public interface IWorkflowState : IDisplayModel {
        IObjectIdentity Name { get; }

        IObjectValue Data { get; }

        IEnumerable<IWorkflowTransition> NextTransitions { get; }
    }
}