# Problem Solving Using Automatically Generated Code
This repository is for the bachelor thesis ***Problem Solving Using Automatically Generated Code*** in information technology at KTH Royal Institute of Technology, written by [Emir Catir](https://github.com/empazi) and [Robin Claesson](https://github.com/RobinClaesson). 

You can find the [fulltext on DiVA](https://kth.diva-portal.org/smash/record.jsf?pid=diva2%3A1770592&dswid=-4134).

## Abstract 
Usage of natural language processing tools to generate code is increasing
together with the advances in artificial intelligence. These tools could improve
the efficiency of software development, if the generated code can be shown
to be trustworthy enough to solve a given problem. This thesis examines
what problems can be solved using automatically generated code such that
the results can be trusted.

A set of six problems were chosen to be used for testing two automatic
code generators and the accuracy of their generated code. The problems
were chosen to span a range from introductory programming assignments
to complex problems with no known efficient algorithm. The problems also
varied in how direct their descriptions were, with some describing exactly what
should be done, while others described a real-world scenario with a desired
result.

The problems were used as prompts to the automatic code generators to
generate code in three different programming languages. A testing framework
was built that could execute the generated code, feed problem instances to the
processes, and then verify the solutions that were outputted from them. The
data from these tests were then used to calculate the accuracy of the generated
code, based on how many of the problem instances were correctly solved.
The experimental results show that most solutions to the problems either
got all outputs correct, or had few or no correct outputs. Problems with
direct explanations, or simple and well known algorithms, such as sorting,
resulted in code with high accuracy. For problems that were wrapped in a
scenario, the accuracy was the lowest. Hence, we believe that identifying
the underlying problem before resorting to code generators should possibly
increase the accuracy of the code.

### Keywords 
automatic code generation, code accuracy, natural language processing, GitHub Copilot, CodePal, problem-solving

## In this repository  
This repository contains all the prompts, generated code, and raw testdata from our work.<br>
Each problem is sorted into its own directory, with sub-directories for code generated by GitHub Copilot and CodePal.<br>
It also contains the source code for our testing framework, and all performed tests, int the directory ProgramTests. <br>
