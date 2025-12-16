# Graduation Folder

This document provides an overview of possible items that students **may include** in their graduation folder. It is not intended to be a strict checklist, but rather a guideline to help students reflect on what evidence they can prepare to best demonstrate their work, growth, and competencies during the graduation project.

The content is a work in progress and will continue to evolve based on feedback from students and colleagues.

## Graduation Folder Structure:

It is recommended to construct your graduation folder as depicted below:

```
|--- Professional Skills, Manage and Control
      |-- [contains all the items prepared for this competency]
      |--...
|--- Analysis
      |-- [contains all the items prepared for this competency]
      |--...
|--- Design
      |-- [contains all the items prepared for this competency]
      |--...
|--- Implementation
      |-- [contains all the items prepared for this competency]
      |--...
|--- Advice
      |-- [contains all the items prepared for this competency]
      |--...
|--- misc
      |-- [contains extra artefacts / reports / evidence that don't fit within the competencies described]
      |--...

readme [read me file according to the templated provided as docx or pdf]
```

## Professional Skills, Manage and Control

This section of the graduation folder contains evidence that demonstrates how the student managed, structured, communicated, and technically controlled the graduation project. The artefacts included here should show professional behavior, informed decision-making, and reflective practice throughout the project.


### Process, Workflow, Project Management

- **Project charter**  
  A concise description of the project’s purpose, scope, stakeholders, constraints, and success criteria, agreed upon with supervisors.

- **Project status and progress reports**  
  Periodic updates that communicate progress, risks, and next steps to stakeholders.

- **Sprint planning notes**  
  Documentation of sprint planning sessions, including selected backlog items and capacity considerations.

- **Sprint goals**  
  Clear statements describing the intended outcome of each sprint and how it contributes to the project objectives.

- **Product backlog**  
  A prioritized list of features, user stories, or tasks, including acceptance criteria where applicable.

- **Retrospective summaries**  
  Reflections on team performance, lessons learned, and improvement actions identified during retrospectives.

- **Work breakdown structure (WBS)**  
  A hierarchical decomposition of the project scope into manageable tasks and deliverables.

- **Priority definitions and criteria**  
  A clear explanation of how priorities were determined and consistently applied throughout the project.

- **Task estimates and time tracking logs**  
  Records comparing estimated effort with actual time spent, including reflections on deviations.

---

### Communication, Collaboration and Planning

- **Meeting agendas and meeting minutes**  
  Structured documentation showing preparation, decisions made, and follow-up actions.

- **Stakeholder update summaries**  
  Regular updates tailored to stakeholders, highlighting progress, risks, and decisions.

- **Feedback collection logs**  
  Evidence of systematically collecting, documenting, and responding to feedback.

- **Collaboration channel guidelines**  
  Agreed rules on how communication tools are used within the project.

- **Project timeline and milestones**  
  A high-level overview of planned phases, key deliverables, and deadlines.

- **Roadmap versions**  
  Iterative project roadmaps that show how direction and priorities evolved over time.

- **Release plans**  
  Documentation describing what is delivered in each release and how releases are validated.

- **Resource allocation plan**  
  An overview of how time, people, or infrastructure were allocated across the project.

- **Knowledge sharing notes**  
  Materials that demonstrate the sharing of insights, decisions, or technical knowledge.

- **Onboarding documentation**  
  Documentation that enables new team members or stakeholders to understand the project quickly.

- **Team agreements and working agreements**  
  Explicit agreements defining collaboration, communication, and decision-making practices.


### Version Control, CI/CD, Cloud Infrastructure

- **Repository structure**  
  An explanation of the organization of the codebase and the rationale behind it.

- **Git workflow (e.g., Gitflow, trunk-based)**  
  A demostration or description of the branching and merging strategy used during development.

- **Commit messages**  
  Examples that demonstrate clear, consistent, and meaningful commit messages.

- **Pull requests and review checklists**  
  Evidence of structured code reviews and quality assurance practices.

- **CI pipeline configuration**  
  Configuration files that automate building, testing, and validation steps.

- **CI metrics summary**  
  Collected metrics such as build times, test results, or coverage, with brief interpretation.

- **Deployment pipeline scripts**  
  Scripts that define automated deployment processes.

- **Deployment rollback procedures**  
  Documentation describing how failed deployments are handled and recovered.

- **Dockerfile with explanation of layers**  
  A container configuration annotated to explain the purpose of each layer.

- **Docker Compose setup for local development**  
  Configuration supporting local development of multi-service applications.

- **Notes on image optimization and caching**  
  Reflections on container optimization techniques applied during the project.

- **Deployment and service YAML manifests**  
  Infrastructure-as-code definitions for deployed services and applications.

- **Documentation on scaling, resource limits, monitoring**  
  Evidence of considerations for performance, reliability, and observability.

- **Cloud resource provisioning notes**  
  Documentation explaining how cloud resources were created, configured, and managed.

- **Scripts to create and destroy development environments**  
  Automation scripts that enable reproducible and disposable environments.

- **Rules for merging, code reviews, tagging, releases**  
  Clearly defined governance rules that ensure code quality and release consistency.



---
## Analysis

This section of the graduation folder contains evidence that demonstrates how the student analyzed the problem domain, existing systems, requirements, and technical context. The artefacts should show structured thinking, informed decision-making, and a clear foundation for later design and implementation choices.

---

### Software Specification Document

- **Complete functional specification of the system**  
  A structured description of what the system must do, covering all required features and behaviors.

- **Detailed non-functional requirements including measurable criteria**  
  Requirements describing quality attributes such as performance, security, usability, and reliability, expressed in measurable terms.

- **System behaviour descriptions for all major interactions**  
  Clear explanations of how the system behaves in response to user actions or external events.

- **Data definitions and data dictionary**  
  Documentation of key data entities, attributes, formats, and relationships used within the system.

- **Interface specifications for user interfaces, external systems, and APIs**  
  Descriptions of how users and other systems interact with the software, including inputs, outputs, and constraints.

- **Inputs, outputs, and workflows for each feature**  
  Step-by-step descriptions of how data flows through the system for each major function.

- **Detailed use case and scenario descriptions**  
  Concrete scenarios illustrating how different users or systems achieve specific goals.

- **Technical assumptions and operational environment details**  
  Explicit assumptions about hardware, software, users, constraints, and deployment context.

- **Traceability matrix linking requirements to specifications**  
  A mapping that shows how each requirement is addressed in the specification, ensuring completeness and consistency.

---

### Analysis of the Current or Previous System

- **Written analysis of existing functionality**  
  A structured description of how the current or legacy system works.

- **Overview of strengths, limitations, and gaps**  
  Evaluation of what works well and what does not, from both technical and functional perspectives.

- **Documented pain points and bottlenecks**  
  Identified issues affecting usability, performance, maintainability, or scalability.

- **Summary of the existing technology stack**  
  Overview of the technologies, frameworks, and tools currently in use.

- **Analysis of the existing architecture or workflows**  
  Examination of how components interact and how processes are organized.

---

### Research Report

- **Problem statement description**  
  A clear and well-defined explanation of the problem being addressed.

- **Background research on domain concepts**  
  Research into the application domain to establish context and understanding.

- **Summary of relevant technologies, frameworks, and libraries**  
  An overview of candidate technical solutions relevant to the project.

- **Comparison table or narrative of alternative solutions**  
  A structured comparison highlighting trade-offs between different approaches.

- **Summary of findings and conclusions**  
  Synthesized insights from the research that guide design and implementation decisions.

---

### Technical Analysis of Existing Assets

- **Analysis report describing structure, dependencies, and issues**  
  Technical evaluation of existing codebases, systems, or components.

- **Dataset analysis describing quality, limitations, and preprocessing needs**  
  Assessment of data completeness, correctness, and required transformations.

- **Review of existing subsystems or frameworks**  
  Evaluation of reuse potential, constraints, and integration challenges.

- **Technical risk list**  
  Identified technical risks with potential impact and mitigation strategies.

- **Technology stack**  
  Overview and justification of the technologies considered or selected.

---

### Early Modellings

- **UML use case diagram**  
  Visual representation of system functionality from the user’s perspective.

- **Context diagram**  
  Diagram showing the system boundaries and interactions with external actors or systems.

- **High-level project overview diagram**  
  A simplified visual overview of the system and its main components.

- **C4 model diagrams describing system context and major components**  
  Structured diagrams that progressively explain the system at different abstraction levels.

---

## Advice

- **Opportunities for improvement report**  
  Clearly formulated improvement opportunities derived from the analysis.

- **Evaluation criteria and justification for chosen approach**  
  Explicit criteria used to evaluate alternatives and reasoning behind the final choice.


- **Project Process improvement proposals**  
  Documents that identify inefficiencies or risks in the current process and propose concrete improvements, supported by rationale.

- **Cost estimation and optimization recommendations**  
  Analysis of infrastructure costs and recommendations for optimization.



[in progress]

## Design

- **Process flow diagrams**  
  Visual representations of how work, data, or decisions flow through the project, showing structure and clarity in the applied process.

- **Cloud architecture diagrams**  
  High-level diagrams showing the cloud services used and their relationships.

- **Container Orchestration Platforms (e.g. Kubernetes) architecture diagrams**  
  Visual representations explaining how components interact within the cluster.
  
- **Dependency mapping**  
  Identification and visualization of dependencies between tasks, components, or external parties.
  
- **Modelling States or state transition (if applicable)**  
  Definitions and visualisation of system states and how transitions occur between them.

- **Interaction, workflow, or dataflow diagrams (previous system and proposed solution)**  
  Diagrams illustrating how components, users, or data interact over time.




[in progress]

## Implementation

[todo]

<!--
## Design

- Structural views
  - Class Diagram
  - ERD Diagram

- High level architectural view
  - Component Diagram
  - Deployment Diagram

- Behavioural views
  - Highe level interactions between your solution and external systems and/or users
  - High level interactions between the internal subsystems, modules
  - workflows, activity diagrams
  - data flows
  - low level interactions for crucial parts of the systems
  - state transitions (if applicable)

- Architecture / Design patterns (if applicable)

- Test Plans
  - design of test: objectives, procedure, methods

- UI mockups (if applicable)

## Implementation

- source code
- a report explaining important pieces of the code
- test scripts
- test results
- configuration / set up files / scripts  

- Automated Testing Pipelines
  - Unit, integration, and end-to-end test configurations
  - Test coverage reports integrated in CI
  - Documentation for running tests locally

- Test
  - Error handling descriptions and exceptional scenarios  



## Advice

All the content of the report must clearly justify the choices and proposals: it must provide clear answers to the questions of "WHY?" with reliable references, experiments, research.

- advice regarding current solution
  - alternatives, pros and cons of each solution, selction criteria
  - risk analysis and cost analysis 

- advice regarding future of the project
  - proposals for the new features
  - proposals for the future technologies
  - proposals for future modifications/improvements/etc
-->

