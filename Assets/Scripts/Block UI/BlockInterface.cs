using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BlockInterface
{
    void BlockRun();

    bool getStatus();

    void blockRaycast();

    void resetBlock();
}
