uniform float time;
varying vec3 N;
varying vec3 L;
varying vec3 V;


void main()
{
	vec4 vertex = gl_Vertex;
	vertex.z += sin( ( (vertex.x * 0.4) + time ) * 10.5 ) * 0.25;

	//vertex.z += sin( ( (vertex.x * 0.4) + time ) * 5.0 ) * 0.25;

	// Vertex to world space to compute light and view vectors
	vec4 world = gl_ModelViewMatrix * vertex;

	// Face Normal Vector gl_NormalMatrix is transpose of the inverse of the top leftmost 3x3
	N = normalize( gl_NormalMatrix * gl_Normal );
	
	vec3 lightPos = vec3( 100.0, 100.0, 0.0 );
	//vec4 lightPos = gl_LightSource[0].position;

	vec3 cameraPos = vec3(gl_ModelViewMatrixInverse[0].w, 
							gl_ModelViewMatrixInverse[1].w, 
							gl_ModelViewMatrixInverse[2].w );

	//vec3 cameraPos = gl_ModelViewMatrixInverse[2].xyz;

	V = normalize( cameraPos - world.xyz );

	L = normalize( lightPos - world.xyz );

	//gl_FrontColor = vec4( 0.8, 0.6, 0.5, 1.0 );
	gl_FrontColor = vec4(N, 1.0);

	gl_TexCoord[0] = gl_MultiTexCoord0;

	gl_Position = gl_ModelViewProjectionMatrix  * vertex;
	//gl_Position = gl_ModelViewProjectionMatrix * Tri[0];
	//gl_Position = gl_ModelViewProjectionMatrix * vertb;
	//gl_Position = gl_ModelViewProjectionMatrix * vertc;
	//gl_Position = ftransform();

}
