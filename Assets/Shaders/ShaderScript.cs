using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderScript : MonoBehaviour {

    public Shader shader;
    public PointLight pointLight;
    public float Ka;
    public float fAtt;
    public float Kd;
    public float Ks;
    public float specN;

    // Use this for initialization
    void Start () {

        // Get MeshRenderer component. This component actually renders the mesh that
        // is defined by the MeshFilter component.
        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
        renderer.material.shader = shader;
    }
	
	// Update is called once per frame
	void Update () {
        // Get renderer component (in order to pass params to shader)
        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();

        // Pass updated light positions to shader
        renderer.material.SetColor("_PointLightColor", this.pointLight.color);
        renderer.material.SetVector("_PointLightPosition", this.pointLight.GetWorldPosition());

        // Pass lighting constants to shader
        renderer.material.SetFloat("_Ka", this.Ka);
        renderer.material.SetFloat("_fAtt", this.fAtt);
        renderer.material.SetFloat("_Kd", this.Kd);
        renderer.material.SetFloat("_Ks", this.Ks);
        renderer.material.SetFloat("_specN", this.specN);
    }

}
