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

This section of the graduation folder contains evidence that demonstrates how the student manages, structures, and controls the graduation project. This includes planning and monitoring the work, communicating progress and decisions with relevant stakeholders, managing risks and changes, and adjusting the approach when necessary. The artefacts should demonstrate professional behaviour, informed decision-making, and responsibility for the progress and quality of the project.

Manage and Control also concerns the technical environment and processes required to develop, test, deploy, and maintain the solution. This may include setting up and improving development and deployment environments, version control, development workflows, automated testing, CI/CD pipelines, configuration management, documentation, and monitoring. The student should demonstrate that these choices support a reliable, efficient, reproducible, and maintainable development process.

The evidence should also demonstrate that the student actively evaluates and improves both the project process and the technical workflow. Through reflection, feedback, monitoring, and lessons learned, the student identifies opportunities for improvement and takes appropriate action. The artefacts should therefore show that the student maintains control over both the organizational and technical aspects of the project throughout its development.


### Project Management, Process, Workflow

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

- **Retrospectives**  
  Evidence of retrospectives and reflections on team performance, lessons learned, and improvement actions identified during retrospectives.

<!--
- **Work breakdown structure (WBS)**  
  A hierarchical decomposition of the project scope into manageable tasks and deliverables.

- **Priority definitions and criteria**  
  A clear explanation of how priorities were determined and consistently applied throughout the project.

- **Task estimates and time tracking logs**  
  Records comparing estimated effort with actual time spent, including reflections on deviations.
-->
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

<!--
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
-->

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

<!--
- **CI metrics summary**  
  Collected metrics such as build times, test results, or coverage, with brief interpretation.

- **Notes on image optimization and caching**  
  Reflections on container optimization techniques applied during the project.

- **Documentation on scaling, resource limits, monitoring**  
  Evidence of considerations for performance, reliability, and observability.

-->
- **Deployment pipeline scripts**  
  Scripts that define automated deployment processes.

- **Deployment rollback procedures**  
  Documentation describing how failed deployments are handled and recovered.

- **Dockerfile with explanation of layers**  
  A container configuration annotated to explain the purpose of each layer.

- **Docker Compose setup for local development**  
  Configuration supporting local development of multi-service applications.


- **Deployment and service YAML manifests**  
  Infrastructure-as-code definitions for deployed services and applications.


- **Cloud resource provisioning notes**  
  Documentation explaining how cloud resources were created, configured, and managed.

- **Scripts to create and destroy development environments**  
  Automation scripts that enable reproducible and disposable environments.

- **Rules for merging, code reviews, tagging, releases**  
  Clearly defined governance rules that ensure code quality and release consistency.



---
## Analysis

This section of the graduation folder contains evidence that demonstrates how the student analyses and develops an understanding of the problem and its context. The purpose of the analysis is to establish a solid foundation for the decisions that will be made later in the project, particularly during design and implementation.

The analysis may address different aspects of the project, including the problem domain, existing systems and solutions, stakeholder needs, functional and non-functional requirements, available data, technical constraints, and the broader technical and organizational context. Depending on the nature of the project, the student may use different methods and techniques to investigate these aspects.

The artefacts should demonstrate structured and systematic thinking. They should make clear what was investigated, how relevant information was collected and evaluated, what conclusions were drawn, and how these conclusions influence the direction of the project. Assumptions, constraints, uncertainties, and important findings should be identified where relevant.

Most importantly, analysis should not be performed as an isolated activity. The student should demonstrate a clear connection between the outcomes of the analysis and the decisions made later in the project. Requirements, design choices, technical decisions, and implementation priorities should be traceable back to relevant findings from the analysis.

The evidence in this section should therefore demonstrate that the student can investigate a problem systematically, interpret the findings, draw well-supported conclusions, and use those conclusions as a foundation for informed design and implementation decisions.

---

### Software Specification Document

- **Complete functional specification of the system**  
  A structured description of what the system must do, covering all required features and behaviors.

- **Detailed non-functional requirements including measurable criteria**  
  Requirements describing quality attributes such as performance, security, usability, and reliability, expressed in measurable terms.

- **System behaviour descriptions for all major interactions**  
  Clear explanations of how the current system behaves in response to user actions or external events.

- **Data definitions**  
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

This section of the graduation folder contains evidence that demonstrates how the student advises the company or client in relation to the problem statement and the outcomes of the project. The advice should be based on the knowledge, analysis, design choices, and results developed during the graduation project. The artefacts should demonstrate structured reasoning and make clear how the student arrived at the recommendations.

In general, two types of advice can be distinguished:

1. Advice regarding the solution to the problem statement.
    This type of advice explains the proposed solution and provides recommendations about how the identified problem can be addressed. The student should connect the advice to relevant findings, requirements, analyses, experiments, or other evidence from the project. The advice should make clear not only what is recommended, but also why this recommendation is appropriate for the company or client.
2. Advice regarding the future of the project.
    A graduation project often ends while further development is still possible or necessary. The student should therefore be able to advise the company about possible next steps. This may include recommendations for further development, implementation, maintenance, evaluation, scaling, additional research, or improvements that were outside the scope of the graduation project.

The evidence in this section should demonstrate that the student can translate the results of the project into clear, well-reasoned, and actionable advice that is relevant to the company or client.

---

- **Opportunities for improvement report**  
  Clearly formulated improvement opportunities derived from the analysis and the implementation of your solution.

- **Evaluation criteria and justification for chosen approach**  
  Explicit criteria used to evaluate alternatives and reasoning behind the final choice. It must be clear why do you think you advice will improve the project.


- **Project Process improvement proposals**  
  Documents that identify inefficiencies or risks in the current process and propose concrete improvements, supported by rationale.

- **Cost estimation and optimization recommendations**  
  Analysis of infrastructure costs and recommendations for optimization.




## Design

Design refers to the choices and decisions you make about how the different components of a system are structured, connected, and interact with each other in order to achieve the goals of the project. Designing is therefore not only about what components are included in a system, but also about why they are organized in a particular way and how they work together.

Within this competency, the student must provide evidence of the design decisions that determine both the structure and the behaviour of the system. This includes identifying relevant components, defining their responsibilities, describing the relationships and interactions between them, and explaining the reasoning behind important design choices.

Modeling is an effective way to make these design decisions explicit and understandable. Models and diagrams can be used to represent different aspects of the system, such as its components and their relationships, the flow of information, or the interactions that take place during a particular process. A good model should not only show what the system looks like, but should also help communicate and justify the design decisions that were made.

---

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

- **Test Design**
  Systematic testing requires a well-defined test design. This includes defining what needs to be tested, the test criteria and scenarios, the test execution plan, and the expected results and acceptance criteria. A proper test design ensures that testing is structured, repeatable, and aligned with the requirements and quality goals of the project.

[in progress]



## Implementation

[in progress]

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

