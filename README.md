## Build Settings

* IL2CPP Code Generation: Faster (Smaller) builds.  
If this is not set, the dialogue in the IntroTutorial scene doesn't start unless you exit back to the menu and restart the Intro.  
    ```
    ExecutionEngineException:
    Attempting to call method 'System.Func`3[
    [System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],
    [System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089],
    [System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]::.ctor'
    for which no ahead of time (AOT) code was generated.
    ```