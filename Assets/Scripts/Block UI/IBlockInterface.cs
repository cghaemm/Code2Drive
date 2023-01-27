using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBlockInterface
{
    void BlockRun();

    bool getStatus();

    void blockRaycast();

    void unBlockRaycast();

    void resetBlock();
}
