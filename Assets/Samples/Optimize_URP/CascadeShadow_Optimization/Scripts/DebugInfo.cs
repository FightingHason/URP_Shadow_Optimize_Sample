using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class DebugInfo : MonoBehaviour
{
    const float fpsMeasurePeriod = 0.5f;
    private int m_FpsAccumulator = 0;
    private float m_FpsNextPeriod = 0;
    private int m_CurrentFps;
    const string display = "{0} FPS";
    public Text m_GuiText;
    // Start is called before the first frame update
    void Start()
    {
        m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
    }

    // Update is called once per frame
    void Update()
    {
        m_FpsAccumulator++;
        if (Time.realtimeSinceStartup > m_FpsNextPeriod)
        {
            StringBuilder debugStats = new StringBuilder(400);
            m_CurrentFps = (int)(m_FpsAccumulator / fpsMeasurePeriod);
            m_FpsAccumulator = 0;
            m_FpsNextPeriod += fpsMeasurePeriod;
            debugStats.Append(string.Format("FPS: {0} \n", m_CurrentFps));
            debugStats.Append(string.Format("三角形个数: {0} \t顶点数: {1} \n", UnityStats.triangles, UnityStats.vertices));
            debugStats.Append(string.Format("渲染批次: {0} \t 投影体个数: {1} \n", UnityStats.batches, UnityStats.shadowCasters));
            m_GuiText.text = debugStats.ToString();
        }
    }
}
