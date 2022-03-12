<template>
         
  <b-modal
    id="user-import-modal"
    ref="user-import-modal"
    hide-header
    
    no-stacking
  >
            <div style="text-align:center; margin:5px; padding: 10px;">
            <span class="svg-tick" >
            <inline-svg src="/media/svg/import/alert-circle.svg" style="justify-self: center;"/>
             </span>
            </div>
           
        <div>

          
        <p style="text-align:center;font-family: Nunito;font-style: normal;font-weight: bold;font-size: 15px;line-height: 20px;">Bạn có muốn Import các khách hàng đủ điều kiện ? </p>           
      <p style="text-align:left;font-family: Nunito;font-style: normal;font-weight: normal;font-size: 15px;line-height: 20px; color:red">( Lưu ý : Các khách hàng có liên quan đến các bản ghi bị lỗi ở trên sẽ không được thêm )</p>
         
          </div>
    <template #modal-footer style="text-align:center">
        <!--<b-button class="btn btn-secondary" href="#" tabindex="0">
          <span class="svg-icon">
            <inline-svg src="/media/svg/icons/Neolex/Basic/power.svg" />
          </span>
          Hủy
        </b-button> -->
      
          

        <b-button
          class="btn btn-success ml-2"
          href="#"
          @click="goback()"
          tabindex="0"
          style="width:90px"
        >
        
          Huỷ
        
        </b-button>

        <b-button
          class="btn btn-success ml-2"
          href="#"
          @click="handleClick()"
          tabindex="0"
        >
        <span class="svg-icon">
            <inline-svg src="/media/svg/import/tick.svg" />
          </span>
         Đồng ý
          
        </b-button>

        
      
      
    </template>
  </b-modal>
</template>

<script>
//import axios from 'axios'
export default {
  props:{
  staff_list:{
    type: Array,
    default: ()=>[],
  }
  },
  name: 'Modal',
 
  computed: {


    
  },
  watch: {},
  // mounted() {this.$root.$on('Modal',()=>{
  //   this.handleClick()
  // })},
  data() {
    return {
      isMounted: false,
      loading: false,
      isSelectFile: false,
      form: {},
      validationState: {},
      error: {},
    };
  },
  methods: {
   async handleClick(){
      this.$store.commit('context/setLoading', true);
    await this.addUser().then(this.goback())
        .finally(() => {
          this.$store.commit('context/setLoading', false);
             this.openModalSuccess();
        });
   
    
     
    },
    async  addUser() {

      for(let i=0;i<=Number(this.staff_list.length);i++)
      {
        await this.$api.post('AccountImport', {headers: {'Content-Type': 'application/json'}}, {
        params: {        
          user_name: this.staff_list[i].user_name,
          user_code: this.staff_list[i].user_code,
          user_gender: this.staff_list[i].user_gender,
          user_yearofbirth: this.staff_list[i].user_yearofbirth,
          user_career: this.staff_list[i].user_career,
          user_phone: this.staff_list[i].user_phone,
          user_hoobit: this.staff_list[i].user_hoobit,
          user_address: this.staff_list[i].user_address,
          user_province: this.staff_list[i].user_province,
          story_success: this.staff_list[i].story_success,
          user_typeofsick: this.staff_list[i].user_typeofsick,
          year_foundout:this.staff_list[i].year_foundout,          
        },
         
        })
        
       await  this.$api.get('AccountImport/id',).then(this.AddSurvey());

        ;;
  }




   },

   async AddSurvey ()
 {
    //  await this.addUser();
    
    const data = await this.$api.get('AccountImport/id')
 
   // const n = data.length 
        for(let j=0;j<=Number(this.staff_list.length);j++)
     {
        const survey_day = new Date(this.staff_list[j].survey_day).toISOString().slice(0, 10);
        const import_day = new Date(this.staff_list[j].import_day).toISOString().slice(0, 10);
       await  this.$api.post('SurveyImport',{headers: {'Content-Type': 'application/json'}}, {
      params: {   
      user_id : data[j].id,
     // user_id: '1a9d3f69-40b2-4206-b59e-dc4ea6c3a18c',
      course_goal: this.staff_list[j].course_goal,
      course_action:this.staff_list[j].course_action,
      course_final_rate:this.staff_list[j].course_final_rate,
      participation_package:this.staff_list[j].participation_package,
      survey_type_code:this.staff_list[j].survey_type_code,
      survey_type:this.staff_list[j].survey_type,
      survey_code:this.staff_list[j].survey_code,
      survey_name:this.staff_list[j].survey_name,
      import_day:  import_day,
      survey_day: survey_day
           
        },
      });
     
   //   await axios.get('https://localhost:44380/api/surveyimport')
    // this.AddSurveyDetails();
     }
    
 },
 
    goback() {
      this.$bvModal.hide('user-import-modal');
    },
    openModalSuccess: function()
    {
        this.$root.$refs.B.clickshow();
    },
  },
};
</script>

<style lang="scss">
.modal-dialog {
  height: 60%;
  width: 600px;
  display: flex;
  align-items: center;
}

.modal-content {
  margin: 0 auto;
}
.modal-footer{
  justify-content: center;
  //text-align: center;
}
.svg-tick{
    justify-content: center;
}


</style>
