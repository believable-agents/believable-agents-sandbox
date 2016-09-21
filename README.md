# Introduction

This project provides examples of how to set-up various aspects of Believable Agent behaviour. This considers the automated planning, scheduling, physiological modifiers, personalities and emotions. 

## Project Info

* Unity version **5.4.1**
* Visual Studio Community Edition 2015
* Windows 10

## Installation

You need to install several programs before you use this project.

1. [Unity 3D](https://unity3d.com/) - Check out which version of the Unity was used to create the project and download the [appropriate version](https://unity3d.com/get-unity/download/archive?_ga=1.50131110.1270362903.1460337485). The current version is always properly documented in *Project Info*
	* When installing unity, install only the bare minimum mentioned below. *Do not install documentation as it is available online and it clutters your space*. Also not install any build environments unless really necessary. Use of Windows only is strongly recommended as it is the most stable environment.
      * Core Files
      * Standard Assets
      * Windows Build
      * Visual Studio Tools
2. [Visual Studio 2015 Community Edition](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx) is strongly recommended to use as it is the most stable environment and the easiest to use. Yet, it can be quite slow and resource hungry. Otherwise, Visual Studio Code works as well. Please install following extensions to Visual Studio
	* Markdown Editor - for maintaining documentation
    * Spell Checker - for the quality of texts.
    * NCrunch - this is a paid extension and is not completely necessary but improves the quality of the work environment

## Collaboration Instructions

### Version control

All projects are setup with git and LFS. 

Please check out these cool tutorials on how to start with Git.

* [https://www.atlassian.com/git/](https://www.atlassian.com/git/)

### Unity

Always use the proposed version of Unity. Never, upgrade unity at your own will. This needs to be a team decision and will be properly documented. After every Unity upgrade a new version will be built and released.

<hr />

### Releases

This project contains several different sub-modules (git repositories). For the ease of use, it is distributed as a zip file containing all the sub modules. Whenever a new version is released, also a new game build is released (windows build).

<hr />

### Programming Language

C# is used as a main programming language. Do not use Unity script at any given time.

<hr />

### Namespacing

While Unity does not enforce namespaces, we enforce the use of namespaces. The default namespace is "Ba". All other projects are sub-namespaced.

<hr />

### Unit Testing*

Any functionality developed in the existing module should be covered by a unit test. Currently the coverage is quite low, but we'll be improving this as time comes.

We are using NUnit with Moq as the main testing and mocking framework.'

<hr />

### Project Organisation

Following are the folders of the Unity project, located in the Assets folder. Also, each of the project modules respects this project hierarchy.

1. **Asset Store** stores any Assets downloaded from the Asset Store
1. **Standard Assets** stores standard Unity assets
1. **Library** is any of the following
   * *Animations* - grouped in folders
   * *Materials*  
   * *Textures*
   * *Props* - anorganic 3D models
   * *Humans* - human avatars
   * *Animals* - animal avatars
   * *Plants* - custom plants
   * *Shaders*
   * *Sounds*
   * *Prefabs*
1. **Resources** any resources that needs to be dynamically loaded at runtime. Do not store too many objects here as it dramatically increases the build size of your project.
1. **Scenes**
1. **Scripts** 
1. **Terrains**
7. **Plugins**
9. **Editor** - custom editor files
8. **Modules** - custom modules with own git repositories

<hr />

### Unity Assets


Following is the description of Unity packages that we use

#### Auto Save

Unity is not the most stable environment, that is why we use the auto save plugin to save the work before every play and after every 5 minutes. The plugin can be configured from *"Window > Unity made awesome > Autosaver"*

Plugin itself resides in the "Assets/Editor/Autosaver"

#### NodeCanvas

Helps author agent behaviour via Decision Trees and FSM

#### SWS

Simple Waypoint System for specifying paths and animations

#### Script Inspector

Allows to modify scripts directly in Unity 

<hr />

### Unity Settings

1. First, you want to turn on Alphanumeric sorting as the transform sorting is very messy and unintuitive in *Edit > Preferences > Enable Alphanumeric Sorting*
2. Setup autosaver in *Window > Unity Made Awesome > Autosaver*  


