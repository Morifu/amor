X=view_xview;
Y=view_yview;
if keyboard_check(vk_space) and mouse_check_button(mb_left){
    global.DRAG=true;
    window_set_cursor(cr_drag);
    view_xview-=vmx;
    view_yview-=vmy;
}else{
    if !keyboard_check(vk_space){
        global.DRAG=false
    }
    window_set_cursor(cr_default);
}

vmx=(mouse_x-X)-omx;
omx=(mouse_x-X);
vmy=(mouse_y-Y)-omy;
omy=(mouse_y-Y);

if mouse_wheel_up(){
    center_of_space_x=view_xview+view_wview/2;
    center_of_space_y=view_yview+view_hview/2;
    view_wview-=view_wview*0.1;
    view_hview-=view_hview*0.1;
    view_xview=center_of_space_x-view_wview/2;
    view_yview=center_of_space_y-view_hview/2;
}
if mouse_wheel_down(){
    center_of_space_x=view_xview+view_wview/2;
    center_of_space_y=view_yview+view_hview/2;
    view_wview+=view_wview*0.1;
    view_hview+=view_hview*0.1;
    view_xview=center_of_space_x-view_wview/2;
    view_yview=center_of_space_y-view_hview/2;
}
