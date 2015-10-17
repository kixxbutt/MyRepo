uniform float time;
uniform vec4 color;
//uniform float Amplitude;
//uniform float Frequencey;
//uniform float Period;

varying vec3 T;
varying vec3 B;
varying vec3 N;

varying vec3 L;
varying vec3 V;

void main()
{	
  	float PI = 3.14159265358979323846264;
  	float angle = 45.0 + time;
  	float rad_angle = angle*PI/180.0;

	float Amplitude = 0.1;
	float Frequencey = 3.0;
	float Period = 2.0;

	vec4 a = gl_Vertex;
	vec4 vertex = a;
	//vertex.y += sin( ( ( vertex.x * Frequencey ) + time ) * Period  ) * Amplitude;
	//vertex.z += sin( ( ( vertex.y * Frequencey ) + time ) * Period  ) * Amplitude;

	// Vertex to world space to compute light and view vectors
	vec4 world = gl_ModelViewMatrix * vertex;
	vec4 newVertex;// = vec4(0.1, 0.1, 0.1, 1.0);

	//newVertex.x = (vertex.x * cos( rad_angle )) - (vertex.z * sin( rad_angle ));
	//newVertex.z = (vertex.z * cos( rad_angle )) + (vertex.x * sin( rad_angle ));
	//newVertex.y = vertex.y;
	//newVertex.w = 1.0;

	// Face Normal Vector gl_NormalMatrix is transpose of the inverse of the top leftmost 3x3
	N = normalize( (gl_ModelViewMatrixInverseTranspose * vec4(gl_Normal,1.0) ).xyz);

	vec3 c1 = cross( gl_Normal, vec3(0.0, 0.0, 1.0) ); 
	vec3 c2 = cross( gl_Normal, vec3(0.0, 1.0, 0.0) ); 

	if( length(c1)>length(c2) )
	{
		T = c1;	
	}
	else
	{
		T = c2;	
	}

	T = normalize(T);

	B = cross(gl_Normal, T);

	B = normalize(B);
	
	// transform light into world space
	vec4 lightPos = vec4( 100.0, 100.0, 100.0, 1.0 );
	//vec4 lightPos = gl_LightSource[0].position;

	vec3 cameraPos = vec3( 	gl_ModelViewMatrixInverse[0].w, gl_ModelViewMatrixInverse[1].w, gl_ModelViewMatrixInverse[2].w );

	V = normalize( cameraPos - world.xyz );

	L = normalize( lightPos.xyz - world.xyz );

	gl_FrontColor = gl_Color;
	//gl_FrontColor = color;

	gl_TexCoord[0] = gl_MultiTexCoord1;


	//gl_Position = gl_ModelViewProjectionMatrix * vertex;
	gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;

}
