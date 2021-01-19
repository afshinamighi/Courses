# Introduction:

This document will collect basics of data anonymization and helpful resources.

# Background:

In this section there will be essential definitions, concepts, examples and required algorithms to understand data anonymization.



## Basic Concepts:

### Data Anonymization: 
Data anonymization (also known as de-identification) is a technique to be applied on datasets containing personal information in which sensitive information about individuals are stored. The main objective of anonymization is to weaken the link between the datasets' personal information and individuals. Anonymized data means that data which previously addressing individuals is processed and after the process the probability of uniquely identifying these individuals becomes less.



### Fundamental Technqies:

#### generalization:

Data generalization is a simple technique by which an exact value of a sensitive attribute is replaced with a more general value. In order to choose a general value, a *taxonomy tree* is built by a (data) domain expert. The exact values must be found among the leaves. The most general value appears in the root.  

Figure: [An example of a taxonomy tree](./pix/fig-taxonomy-01.png)

#### suppression:



#### permutation:



#### swapping:



### Fundamental Algorithms:



#### k-anonimity:

[todo]

#### l-diversity:

[todo]

# Resources:

## Books:

1. Book: ["Database Anonymization: Privacy Models, Data Utility, and Microaggregation-based Inter-model Connections"](https://www.researchgate.net/publication/290229262_Database_Anonymization_Privacy_Models_Data_Utility_and_Microaggregation-based_Inter-model_Connections)

## Surveys:

1. Privacy-preserving data publishing: A survey of recent development [[download here](https://dl-acm-org.ezproxy.hro.nl/doi/10.1145/1749603.1749605)]

## Tools:

1. Tool: [ARX as an anonymization tool and API](https://arx.deidentifier.org/)
2. Tool: [ARX as a Service](https://oslomet-arx-as-a-service.github.io/resources/Product_Specification.pdf)

## Reports:

1. A bachelor thesis: [Anonymization of health data](https://www.duo.uio.no/bitstream/handle/10852/79902/Anonymization-of-Health-Data.pdf?sequence=13&isAllowed=y)

