#version 120
uniform float time;

void main()
{
	vec4 vertex = gl_Vertex;
	gl_TexCoord[0] = gl_MultiTexCoord0 * 1.0;
	gl_Position = gl_ModelViewProjectionMatrix * vertex;
}
