using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEventSystem : MonoBehaviour
{
    #region Singleton
    public static MyEventSystem current;
    private void Awake() => current = this;
    #endregion

    #region Excample
    /*
    @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public event Action gdyCośSięStanie
    public void CośSięStało()
    {
        if(gdyCośSięStanie != null)
            gdyCośSięStanie();
    }

    @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    @@@@@@@@@@@@@@@@@ Również @@@@@@@@@@@@@@@@@@

    public event Action<T> gdyCośSięStanie
    public void CośSięStało()
    {
        if(gdyCośSięStanie != null)
            gdyCośSięStanie(zmiennaTypuT);
    }

    */
    #endregion

    #region Events

    #region Pedestal

    // public event Action whenNewPedestalinstantiated;
    // public void NewPedestalinstantiated()
    //{
    //    if (whenNewPedestalinstantiated != null)
    //        whenNewPedestalinstantiated();
    //}

    public event Action whenPedestalChangedState;
    public void PedestalChangedState()
    {
        if (whenPedestalChangedState != null)
            whenPedestalChangedState();
    }

    #endregion

    #region Portal

    #endregion

    #region Interactions

    #endregion

    #endregion
}
