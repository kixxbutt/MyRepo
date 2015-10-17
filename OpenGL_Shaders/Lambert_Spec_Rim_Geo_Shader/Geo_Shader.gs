varying vec3 N;
varying vec3 L;
varying vec3 V;

void main()
{
	gl_FrontColor = gl_FrontColorIn[0];
	gl_TexCoord[0] = gl_TexCoordIn[0][0];
	gl_Position = gl_PositionIn[0];
	EmitVertex();

	gl_FrontColor = gl_FrontColorIn[1];
	gl_TexCoord[0] = gl_TexCoordIn[1][0];
	gl_Position = gl_PositionIn[1] + vec4(0.0, 0.4, 0.0, 1.0);
	EmitVertex();

	gl_FrontColor = gl_FrontColorIn[2];
	gl_TexCoord[0] = gl_TexCoordIn[2][0];
	gl_Position = gl_PositionIn[2] + vec4(0.0, 0.4, 0.0, 1.0);
	EmitVertex();

	EndPrimitive();
}
