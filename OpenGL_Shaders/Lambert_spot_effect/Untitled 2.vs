#version 120
uniform float time;
uniform vec3 LightPos;
varying vec3 N;
varying vec3 L;
varying vec3 V;

uniform vec3 triangleVertex[3] = vec3[3](vec3(0.0, 0.0, 0.0), vec3(1.0, 0.0, 0.0), vec3(0.0, 1.0, 0.0) );


void main()
{	

	//float array[3] = float[]( (2.5), (7.0), (1.5) );
	
	vec3 vertexPos = triangleVertex[0];

	vec4 vertex = gl_Vertex;
	//vertex.z += sin( ( ( vertex.x * 1.0 ) + time ) * 4.0 ) * 0.25;
	//vertex.x += cos( ( ( vertex.y * 1.0 ) + time ) * 4.0 ) * 0.25;

	// Vertex to world space to compute light and view vectors
	vec4 world = gl_ModelViewMatrix * vertex;

	// Face Normal Vector gl_NormalMatrix is transpose of the inverse of the top leftmost 3x3
	N = normalize( gl_NormalMatrix * gl_Normal );

	vec3 cameraPos = vec3( 	gl_ModelViewMatrixInverse[0].w, gl_ModelViewMatrixInverse[1].w, gl_ModelViewMatrixInverse[2].w );

	V = normalize( cameraPos - world.xyz );

	L = normalize( LightPos - world.xyz );

	//gl_FrontColor = vec4( 0.8, 0.6, 0.5, 1.0 );
	//gl_FrontColor = vec4(N, 1.0);

	gl_TexCoord[0] = gl_MultiTexCoord0 * 1.0;

	gl_Position = gl_ModelViewProjectionMatrix * vertex;
	//gl_Position = ftransform();

}
