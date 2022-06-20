# Personal Data Minimization:

## Introduction:
This document presents basic concepts and simple exercises to practice Data Anonymization.

## Basic Concepts:

### Data Anonymization: 
Data anonymization (also known as de-identification or data minimization) is a technique to be applied on datasets containing personal information in which sensitive information about individuals are stored. The main objective of anonymization is to weaken the link between the datasets' personal information and individuals. Anonymized data means that data which previously addressing individuals is processed and after the process the probability of uniquely identifying these individuals becomes less. 


### Fundamental Technqies:

#### Generalization: 
Data generalization is a simple technique by which an exact value of a sensitive attribute is replaced with a more general value. In order to choose a general value, a *taxonomy tree* is built by a (data) domain expert. The exact values must be found among the leaves. The most general value appears in the root.  

Examples of taxonomy trees: ![An example of a taxonomy tree](./pix/fig-taxonomy-01.png)

#### Suppression:
Suppression is used to obliterate values that are identifying individuals. One common example could be replacing values of social security numbers with ' * '.

### Fundamental Algorithms:

#### k-anonimity:

This algorithm is based on QIDs. The algorithm using taxonomy tree, builds a class of records with equal values for *qids*. After applying k-anonymity, if one record in the table has some value *qid*, at least *k* − 1 other records also have the value *qid*. In other words, the minimum group size on *QID* is at least *k*. A table satisfying this requirement is called *k-anonymous*. In a *k*-anonymous table, each record is indistinguishable from at least *k* − 1 other records with respect to *QID*. Consequently, the probability of linking a victim to a specific record through *QID* is at most 1/*k*.

#### l-diversity:

This algorithm focuses on sensitive (confidential) attributes. After applying *k-anonymity*, the dataset can be viewed as a set of *k-anonymous groups* (equivalence classes). The goal is to have at least *l distinct values* for each sensitive attribute within equivalence classes.



## Exercises:

### Part Zero :
1. Make a anonymisation-pseudonymisation plan. This should include the following information: 
creator(s) of the plan, person(s) carrying out the anonymisation, features in the data that have an impact on anonymisation, assessment of the disclosure risk of respondents' personal data, anonymisation techniques used along with the rationale for using them. You can use this template which [can be found here](https://www.fsd.tuni.fi/en/services/data-management-guidelines/anf-template.pdf)
2. K-anonymity: Apply 4-anonymity (*ad-hoc*) on this dataset: [a simple dataset is available here](./datasets/ds_med_01.csv).
	- What are the main challenges in building a k-anonyous table?

### Part One :

For the following exercises use this simple medical dataset:

##### Data Set: 
Consider the data set below in the following exercises.

| SSNumber | Age | ZipCode | Condition |
|---|---|---|---|
| 1234-12-1234 | 21 | 23058 | heart disease |
| 2345-23-2345 | 24 | 23059 | heart disease |
| 3456-34-3456 | 26 | 23060 | viral infection | 
| 4567-45-4567 | 27 | 23061 | viral infection | 
| 9012-90-9012 | 32 | 23058 | kidney stone | 
| 0123-12-0123 | 34 | 23059 | kidney stone | 
| 4321-43-4321 | 35 | 23060 | aids | 
| 5432-54-5432 | 38 | 23061 | aids | 
| 5678-56-5678 | 43 | 23058 | kidney stone | 
| 6789-67-6789 | 43 | 23059 | heart disease | 
| 7890-78-7890 | 47 | 23060 | viral infection | 
| 8901-89-8901 | 49 | 23061 | viral infection | 


1. EIDs (Explicit IDentifiers): Which attribute is an explicit identifier? Transform the original data set to a new data set where it protects re-identifying individuals regardin EIDs.

2. QIDs (Quasi IDentifiers): Which attributes can be candidates for QIDs?

3. Taxonomy Tree: Define a taxonomy tree for **Age** in 4 levels. Lowest level, i.e. **Age_0** will be the values in the data set.

4. Taxonomy Tree: Define a taxonomy tree for **ZipCode**.

5. Taxonomy Tree: Assume an attribute **Job** with the following values:
```Job={Software Developer,Writer,Civil Engineer,Lawyer,Dancer,Graphist,Journalist}```
Propose a taxonomy tree for **Job**.

6. 2-anonymity: For the moment assume **Condition** as a non-sensitive attribute. Use your taxonomy trees and try to transform the original data set to a minimized data set where it satistifies *2-anonymity*.
	- Is there only one solution or more?


7. 4-anonymity: For the moment assume **Condition** as a non-sensitive attribute. Use your taxonomy trees and try to transform the original data set to a minimized data set where it satistifies *4-anonymity*.
	- Is there only one solution or more?

8. Optimum Solution: In case you have found more solutions for your transformed data set, which one would you prefer as an *optimum solution*?

9. 2-Diversity: **Condition** is a sensitive attriubte. Transform your *4-anonymity* solution to a new data set where it it satisfies *2-diversity*.

### Part Two :

To carry the exercises of this part, you can use our simple medical data set (Part One) or a (larger) fake data set [available here](./datasets/dataset-fake-2021/)

1. ARX: Download and install ARX [Check here: https://arx.deidentifier.org/](https://arx.deidentifier.org/) 
2. Taxonomies as CSVs: Convert your taxonomy trees (from Part One) of **Age** and **ZipCode** to CSV formats.
3. ARX: Watch provided tutorial video to explore basic steps of ARX and try to anonymize our data set: 4-anonymity and 2-diversity.
4. ARXaaS: Using ARXaaS [Check here](http://145.24.222.216:3000/) and try to anonymize our data set: 4-anonymity and 2-diversity. 
**Important**: Do not use this link for sensitive information. This link is provided only for educational purpose.

# Resources:

## Books

1. Book: ["Database Anonymization: Privacy Models, Data Utility, and Microaggregation-based Inter-model Connections"](https://www.researchgate.net/publication/290229262_Database_Anonymization_Privacy_Models_Data_Utility_and_Microaggregation-based_Inter-model_Connections)

## Survey

1. Privacy-preserving data publishing: A survey of recent development [[download here](https://dl-acm-org.ezproxy.hro.nl/doi/10.1145/1749603.1749605)]

## Tool

1. Tool: [ARX as an anonymization tool and API](https://arx.deidentifier.org/)
2. Tool: [ARX as a Service](https://oslomet-arx-as-a-service.github.io/resources/Product_Specification.pdf)

### Report

1. A bachelor thesis: [Anonymization of health data](https://www.duo.uio.no/bitstream/handle/10852/79902/Anonymization-of-Health-Data.pdf?sequence=13&isAllowed=y)



### misc

1. Fundamentals in data anonimization. [Read here](https://www.dataversity.net/the-fundamentals-of-data-anonymization-and-protection/#)
2. Is it still possible to identify anonymized data? [Read here](https://www.nytimes.com/2019/07/23/health/data-privacy-protection.html)


