var start_x = x 
var start_y = y


var point1 = instance_create(start_x,start_y,obj_chainPoint);
physics_joint_revolute_create(point1,self,x,y,0,0,0,0,0,0,0);


for(i = 0; i<argument0; i++)
{
  var length = i*10;
  point2 = instance_create(start_x,start_y+length,obj_chainPoint);
  physics_joint_revolute_create(point1, point2,point1.x,point1.y,0,0,0,0,0,0,0);
  point1 = point2;
  
}

