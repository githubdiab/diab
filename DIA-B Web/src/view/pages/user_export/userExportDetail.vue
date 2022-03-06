<template>
  <div class="user-app-detail-page w-100">
    <b-form @submit="handleValidate">
      <basic-subheader>
        <template v-slot:actions>
          <b-button
            class="btn btn-light ml-3"
            type="button"
            @click="returnPage"
          >
            <span class="svg-icon">
              <inline-svg src="/media/svg/icons/Neolex/Arrows/arrow-left.svg" />
            </span>
            Trở về trước
          </b-button>
          <b-button
            v-if="isEditForm"
            class="btn btn-light ml-3"
            type="button"
            @click="resetData"
          >
            <span class="svg-icon">
              <inline-svg src="/media/svg/icons/Neolex/Basic/refresh-cw.svg" />
            </span>
            Reset dữ liệu
          </b-button>
          <b-button
            class="btn btn-danger ml-3"
            type="button"
            v-if="isEditForm"
            @click="closeReport"
          >
            <span class="svg-icon">
              <inline-svg src="/media/svg/icons/Neolex/Basic/close.svg" />
            </span>
            Đóng báo cáo
          </b-button>
          <template v-if="isEditForm">
            <b-button class="btn btn-success ml-3" @click.stop="handleValidate">
              <span class="svg-icon">
                <inline-svg :src="`/media/svg/icons/Neolex/Basic/save.svg`" />
              </span>
              Cập nhật
            </b-button>
          </template>
        </template>
      </basic-subheader>
      <b-overlay :show="loading">
        <b-container fluid class="user-app-list-page__body mb-6 mt-6">
          <b-row>
            <b-col>
              <div class="card card-custom gutter-b">
                <div class="card-body mt-0">
                  <h5 class="card-title text-success">Thông tin cá nhân</h5>
                  <b-row>
                    <b-col cols="4">
                      <div
                        class="d-flex flex-column align-items-center justify-content-center"
                      >
                        <div
                          style="
                            width: 150px;
                            height: 150px;
                            background-color: #f3f6f9;
                            box-shadow: 0px 4px 4px 0px #000000 10%;
                            position: relative;
                            margin: auto;
                          "
                        >
                          <v-file-input
                            hide-input
                            v-model="file"
                            accept="image/png, image/jpeg, image/bmp"
                            class="icon-edit"
                            @change="onUpload"
                            prepend-icon="mdi-pencil-outline"
                            truncate-length="15"
                          >
                          </v-file-input>
                          <v-img :src="preview" :aspect-ratio="1 / 1"></v-img>
                          <!-- <v-icon
                            @click="clear"
                            v-if="preview"
                            style="
                              position: absolute;
                              bottom: -10px;
                              right: -10px;
                            "
                          >
                            mdi-cancel</v-icon
                          > -->
                        </div>
                      </div>
                    </b-col>
                    <b-col>
                      <b-row>
                        <b-col>
                          <basic-input
                            label="Họ và Tên"
                            placeholder="Nhập họ và tên"
                            name="userName"
                            :required="true"
                            data-vv-as="Họ và tên"
                            v-validate="'required|max:50'"
                            :value.sync="form.userName"
                            :state="validateState('userName')"
                            :invalidFeedback="errors.first('userName')"
                          ></basic-input>
                        </b-col>
                        <b-col>
                          <basic-input
                            label="Năm sinh"
                            placeholder="Nhập năm sinh"
                            name="userYearofbirth"
                            :required="true"
                            v-validate="'required|min:4|max:4'"
                            inputType="number"
                            data-vv-as="Năm sinh"
                            :value.sync="form.userYearofbirth"
                            :state="validateState('userYearofbirth')"
                            :invalidFeedback="errors.first('userYearofbirth')"
                          ></basic-input>
                        </b-col>
                      </b-row>
                      <b-row>
                        <b-col>
                          <basic-select
                            label="Giới tính"
                            placeholder="--- Chọn giới tính ---"
                            name="userGender"
                            :required="true"
                            data-vv-as="giới tính"
                            v-validate="'required'"
                            :options="isGenderOpts"
                            :value.sync="form.userGender"
                            :state="validateState('userGender')"
                            :invalidFeedback="errors.first('userGender')"
                            changeValueByObject
                            valueLabel="name"
                          />
                        </b-col>
                        <b-col>
                          <!--
                          <basic-select
                            label="Nghề nghiệp"
                            placeholder="--- Chọn nghề nghiệp ---"
                            name="userCareer"
                            :options="isCareerOpts"
                            :changeValueByObject="true"
                            :value.sync="form.userCareer"
                            :searchable="false"
                            valueLabel="name"
                          />
                          -->
                          <basic-input
                            label="Nghề nghiệp"
                            placeholder="Nhập nghề nghiệp"
                            name="userCareer"
                            :required="true"
                            data-vv-as="Nghề nghiệp"
                            v-validate="'required|max:50'"
                            :value.sync="form.userCareer"
                            :state="validateState('userCareer')"
                            :invalidFeedback="errors.first('userCareer')"
                          ></basic-input>
                        </b-col>
                      </b-row>
                      <b-row>
                        <b-col>
                          <!--
                          <basic-select
                            label="Tỉnh thành"
                            placeholder="--- Chọn tỉnh thành ---"
                            name="userProvince"
                            :apiPath="'/Division/Provinces'"
                            :searchField="'searchTerm'"
                            :searchable="false"
                            valueLabel="name"
                            valueKey="name"
                            :changeValueByObject="true"
                            :value.sync="form.userProvince"
                            :state="validateState('userProvince')"
                            :invalidFeedback="errors.first('userProvince')"
                          />
                          -->
                          <basic-input
                            label="Tỉnh thành"
                            placeholder="Nhập tỉnh thành"
                            name="userProvince"
                            :required="true"
                            data-vv-as="Tỉnh thành"
                            v-validate="'required|max:50'"
                            :value.sync="form.userProvince"
                            :state="validateState('userProvince')"
                            :invalidFeedback="errors.first('userProvince')"
                          ></basic-input>
                        </b-col>
                        <b-col>
                          <!--
                          <basic-select
                            label="Tip ĐTĐ"
                            placeholder="--- Chọn típ đtđ ---"
                            name="userTypeofsick"
                            :options="isTypeofsickOpts"
                            :value.sync="form.userTypeofsick"
                            :changeValueByObject="true"
                            :searchable="false"
                            valueLabel="name"
                          />
                          -->
                          <basic-input
                            label="Tip ĐTĐ"
                            placeholder="Nhập tip ĐTĐ"
                            name="userTypeofsick"
                            :required="true"
                            data-vv-as="Tip ĐTĐ"
                            v-validate="'max:50'"
                            :value.sync="form.userTypeofsick"
                            :state="validateState('userTypeofsick')"
                            :invalidFeedback="errors.first('userTypeofsick')"
                          ></basic-input>
                        </b-col>
                      </b-row>
                      <b-row>
                        <b-col>
                          <!--
                          <basic-select
                            label="Thời gian phát hiện bệnh"
                            placeholder="--- Chọn thời gian phát hiện bệnh ---"
                            name="yearFoundout"
                            :options="isYearFoundoutOpts"
                            :value.sync="form.yearFoundout"
                            :changeValueByObject="true"
                            :searchable="false"
                            valueLabel="name"
                          />
                          -->
                          <basic-input
                            label="Năm phát hiện bệnh"
                            placeholder="Nhập năm phát hiện bệnh"
                            name="yearFoundout"
                            :required="true"
                            v-validate="'min:4|max:4'"
                            inputType="number"
                            data-vv-as="Năm phát hiện bệnh"
                            :value.sync="form.yearFoundout"
                            :state="validateState('yearFoundout')"
                            :invalidFeedback="errors.first('yearFoundout')"
                          ></basic-input>
                        </b-col>
                        <b-col>
                          <basic-input
                            label="Sở thích"
                            placeholder="Nhập sở thích"
                            name="userHoobit"
                            :value.sync="form.userHoobit"
                            v-validate="'max:50'"
                            :state="validateState('userHoobit')"
                            :invalidFeedback="errors.first('userHoobit')"
                          ></basic-input>
                        </b-col>
                      </b-row>
                    </b-col>
                  </b-row>
                  <hr style="margin: 2rem -2.25rem" />
                  <h5 class="card-title text-success">Báo cáo tổng quan</h5>
                  <b-row>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >HbA1C</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.hba1cVal }}</span
                      >
                    </b-col>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >BMI</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.bmiVal }}</span
                      >
                    </b-col>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Kiến thức</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.ktVal }}</span
                      >
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Khả năng tự chăm sóc</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.kntcsVal }}</span
                      >
                    </b-col>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Mức độ rào cản</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.mdrcVal }}</span
                      >
                    </b-col>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Khả năng điều chỉnh tâm lý</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.kndctlVal }}</span
                      >
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <basic-text-area
                        label="Nhận xét"
                        placeholder="Ghi nhận xét tổng quát"
                        name="nxtq"
                        :value.sync="form.nxtq"
                        :state="validateState('nxtq')"
                        :invalidFeedback="errors.first('nxtq')"
                      ></basic-text-area>
                    </b-col>
                  </b-row>

                  <hr style="margin: 2rem -2.25rem" />
                  <h5 class="card-title text-success">Kiến thức</h5>
                  <b-row>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Điểm tổng thể</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.ktVal }}</span
                      >
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Bệnh lý</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.ktBlVal }}</span
                      >
                    </b-col>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Theo dõi chỉ số</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.ktTdcsVal }}</span
                      >
                    </b-col>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Dinh dưỡng</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.ktDdVal }}</span
                      >
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Vận động</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.ktVdVal }}</span
                      >
                    </b-col>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Tinh thần</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.ktThVal }}</span
                      >
                    </b-col>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Tâm lý hành vi</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.ktTlhvVal }}</span
                      >
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <basic-text-area
                        label="Nhận xét"
                        placeholder="Ghi nhận xét tổng quát"
                        name="ktNxtq"
                        :value.sync="form.ktNxtq"
                        :state="validateState('ktNxtq')"
                        :invalidFeedback="errors.first('ktNxtq')"
                      ></basic-text-area>
                    </b-col>
                  </b-row>

                  <hr style="margin: 2rem -2.25rem" />
                  <h5 class="card-title text-success">Khả năng tự chăm sóc</h5>
                  <b-row>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Điểm tổng thể</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.kntcsVal }}</span
                      >
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Hút thuốc</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.kntcsHtVal }}</span
                      >
                    </b-col>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Chăm sóc bàn chân</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.kntcsCsbcVal }}</span
                      >
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Theo dõi đường huyết
                      </span>
                      <span class="font-weight-bolder text-right">
                        {{ form.kntcsTddhVal }}</span
                      >
                    </b-col>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Chế độ vận động</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.kntcsCdvdVal }}</span
                      >
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <basic-text-area
                        label="Nhận xét"
                        placeholder="Ghi nhận xét tổng quát"
                        name="kntcsNxtq"
                        :value.sync="form.kntcsNxtq"
                        :state="validateState('kntcsNxtq')"
                        :invalidFeedback="errors.first('kntcsNxtq')"
                      ></basic-text-area>
                    </b-col>
                  </b-row>

                  <hr style="margin: 2rem -2.25rem" />
                  <h5 class="card-title text-success">Mức độ rào cản</h5>
                  <b-row>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Điểm tổng thể</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.mdrcVal }}</span
                      >
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Dùng thuốc</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.mdrcDtVal }}</span
                      >
                    </b-col>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Theo dõi dường huyết</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.mdrcTddhVal }}</span
                      >
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Chế độ vận động
                      </span>
                      <span class="font-weight-bolder text-right">
                        {{ form.mdrcCdvdVal }}</span
                      >
                    </b-col>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Chế độ ăn uống</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.mdrcCdauVal }}</span
                      >
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <basic-text-area
                        label="Nhận xét"
                        placeholder="Ghi nhận xét tổng quát"
                        name="kntcsNxtq"
                        :value.sync="form.mdrcNxtq"
                        :state="validateState('mdrcNxtq')"
                        :invalidFeedback="errors.first('mdrcNxtq')"
                      ></basic-text-area>
                    </b-col>
                  </b-row>

                  <hr style="margin: 2rem -2.25rem" />
                  <h5 class="card-title text-success">
                    Khả năng điều chỉnh tâm lý
                  </h5>
                  <b-row>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Điểm tổng thể</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.kndctlVal }}</span
                      >
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Căng thẳng liên quan đến bác sĩ</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.kndctlCtlqdbsVal }}</span
                      >
                    </b-col>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Căng thẳng trong các mối quan hệ</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.kndctlCttcmqhVal }}</span
                      >
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Gánh nặng về tuân thủ điều trị
                      </span>
                      <span class="font-weight-bolder text-right">
                        {{ form.kndctlGnvttdtVal }}</span
                      >
                    </b-col>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Gánh nặng cảm xúc</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.kndctlGncxVal }}</span
                      >
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <basic-text-area
                        label="Nhận xét"
                        placeholder="Ghi nhận xét tổng quát"
                        name="kndctlNxtq"
                        :value.sync="form.kndctlNxtq"
                        :state="validateState('kndctlNxtq')"
                        :invalidFeedback="errors.first('kndctlNxtq')"
                      ></basic-text-area>
                    </b-col>
                  </b-row>

                  <hr style="margin: 2rem -2.25rem" />
                  <h5 class="card-title text-success">Động lực thay đổi</h5>
                  <b-row>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Động lực thay đổi bên trong</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.dltdDltdbtVal }}</span
                      >
                    </b-col>
                    <b-col>
                      <span
                        class="font-weight-bold text-muted font-size-lg mr-2"
                        >Động lực thay đổi bên ngoài</span
                      >
                      <span class="font-weight-bolder text-right">
                        {{ form.dltdDltdbnVal }}</span
                      >
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <basic-text-area
                        label="Nhận xét"
                        placeholder="Ghi nhận xét tổng quát"
                        name="dltdNxtq"
                        :value.sync="form.dltdNxtq"
                        :state="validateState('dltdNxtq')"
                        :invalidFeedback="errors.first('dltdNxtq')"
                      ></basic-text-area>
                    </b-col>
                  </b-row>

                  <hr style="margin: 2rem -2.25rem" />
                  <h5 class="card-title text-success">
                    Nhận xét và khuyến nghị
                  </h5>
                  <b-row>
                    <b-col>
                      <basic-text-area
                        label="Đề xuất và mục tiêu cần đạt được"
                        placeholder="Ghi đề xuất và mục tiêu"
                        name="dxvmtNxtq"
                        :value.sync="form.dxvmtNxtq"
                        :state="validateState('dxvmtNxtq')"
                        :invalidFeedback="errors.first('dxvmtNxtq')"
                      ></basic-text-area>
                    </b-col>
                  </b-row>
                  <b-row>
                    <b-col>
                      <basic-text-area
                        label="Kế hoạch và hành động"
                        placeholder="Ghi kế hoạch và hành động"
                        name="khvhdNxtq"
                        :value.sync="form.khvhdNxtq"
                        :state="validateState('khvhdNxtq')"
                        :invalidFeedback="errors.first('khvhdNxtq')"
                      ></basic-text-area>
                    </b-col>
                  </b-row>
                </div>
                <div
                  v-if="isEditForm"
                  class="card-footer d-flex align-items-lg-center justify-content-center"
                >
                  <b-button
                    v-if="isEditForm"
                    class="btn btn-light ml-3"
                    type="button"
                    @click.stop="resetData"
                  >
                    <span class="svg-icon">
                      <inline-svg
                        src="/media/svg/icons/Neolex/Basic/refresh-cw.svg"
                      />
                    </span>
                    Reset dữ liệu
                  </b-button>
                  <b-button
                    class="btn btn-success ml-3"
                    @click.stop="handleValidate"
                  >
                    <span class="svg-icon">
                      <inline-svg
                        src="/media/svg/icons/Neolex/Basic/save.svg"
                      />
                    </span>
                    Cập nhật
                  </b-button>
                </div>
              </div>
            </b-col>
          </b-row>
        </b-container>
      </b-overlay>
    </b-form>
  </div>
</template>

<script>
export default {
  components: {},
  props: {
    id: {
      type: String,
      default: null,
    },
    form_type: {
      type: String,
      default: 'edit',
    },
  },
  data() {
    return {
      isGenderOpts: [
        { id: 'Nam', name: 'Nam' },
        { id: 'Nữ', name: 'Nữ' },
      ],
      isCareerOpts: [{ id: 'Văn phòng', name: 'Văn phòng' }],
      isTypeofsickOpts: [
        { id: 'Tip 1', name: 'Tip 1' },
        { id: 'Tip 2', name: 'Tip 2' },
        { id: 'Tip 3', name: 'Tip 3' },
      ],
      isYearFoundoutOpts: [
        { id: '< 1 năm', name: '< 1 năm' },
        { id: '1 ~ 5 năm', name: '1 ~ 5 năm' },
        { id: '6 ~ 10 năm', name: '6 ~ 10 năm' },
        { id: '> 10 năm', name: '> 10 năm' },
      ],
      isServicePackOpts: [
        { id: 0, name: 'Thành viên Cơ Bản' },
        { id: 1, name: 'Thành viên Đồng' },
        { id: 2, name: 'Thành viên Bạc' },
        { id: 3, name: 'Thành viên Vàng' },
      ],
      isDiabetesConditionOpts: [
        { id: 0, name: 'Tiểu đường loại 1' },
        { id: 1, name: 'Tiểu đường loại 2' },
        { id: 2, name: 'Tiểu đường loại 3' },
        { id: 3, name: 'Tiểu đường loại 4' },
      ],
      form: {},
      file: null,
      preview: null,
      loading: false,
    };
  },
  created() {
    this.loadUserData();
  },
  computed: {
    isEditForm() {
      return this.form_type === 'edit';
    },
  },
  methods: {
    async resetData() {
      await this.loadUserData();

      this.$nextTick(() => {
        this.$validator.reset();
      });
    },
    clear() {
      this.file = null;
      this.preview = null;
    },

    async closeReport() {
      let id = this.$route.params.id;
      let confirm = await this.$swal({
        text: `Bạn có chắc muốn đóng báo cáo này không?`,
        icon: 'warning',
        buttons: {
          cancel: {
            text: 'Quay lại',
            value: false,
            visible: true,
            className: '',
            closeModal: true,
          },
          confirm: {
            text: 'Đóng báo cáo',
            value: true,
            visible: true,
            className: 'btn-success',
            closeModal: true,
          },
        },
      });
      if (!confirm) return;
      try {
        this.loading = true;

        await this.$api.put(`Admin/SurveyImport/result/${id}`);
        await this.$swal({
          text: `Đóng báo cáo thành công! Báo cáo này sẽ không còn hiển thị nữa.`,
          icon: 'success',
          confirm: {
            text: 'OK',
            value: true,
            visible: true,
            className: 'btn-success',
            closeModal: true,
          },
        });

        this.$router.push({ name: 'user_export_list' });
      } catch (e) {
        this.$toastr.e({
          title: 'Lỗi!',
          msg: e,
        });
      } finally {
        this.loading = false;
      }
    },
    onUpload() {
      this.preview = URL.createObjectURL(this.file);
    },
    notBeforeToday(date) {
      return date > new Date();
    },
    validateState(ref) {
      if (
        this.veeFields[ref] &&
        (this.veeFields[ref].dirty || this.veeFields[ref].validated)
      ) {
        return !this.errors.has(ref);
      }
      return null;
    },
    async returnPage() {
      if (this.isEditForm) {
        (await this.handleConfirm())
          ? this.$router.push({
              name: 'user_export_list',
            })
          : null;
      } else {
        this.$router.push({
          name: 'user_export_list',
        });
      }
    },
    async handleConfirm() {
      let confirm = await this.$swal({
        text: 'Các thay đổi sẽ không được lưu trữ, bạn có chắc muốn huỷ?',
        icon: 'warning',
        buttons: {
          cancel: {
            text: 'Quay lại',
            value: false,
            visible: true,
            className: '',
            closeModal: true,
          },
          confirm: {
            text: 'Huỷ',
            value: true,
            visible: true,
            className: 'btn-warning',
            closeModal: true,
          },
        },
      });
      return confirm;
    },
    async handleValidate() {
      let result = await this.$validator.validateAll();
      if (!result) return;
      else {
        this.submit();
      }
    },
    async submit() {
      let payload = new FormData();
      this.form.userName && payload.append('userName', this.form.userName);
      this.form.userYearofbirth &&
        payload.append('userYearofbirth', this.form.userYearofbirth);
      this.form.userGender &&
        payload.append('userGender', this.form.userGender.id);
      this.form.userCareer &&
        payload.append('userCareer', this.form.userCareer);
      this.form.userProvince &&
        payload.append('userProvince', this.form.userProvince);
      this.form.userTypeofsick &&
        payload.append('userTypeofsick', this.form.userTypeofsick);
      this.form.yearFoundout &&
        payload.append('yearFoundout', this.form.yearFoundout);
      this.form.userHoobit &&
        payload.append('userHoobit', this.form.userHoobit);
      this.file && payload.append('image', this.file);

      this.form.ktNxtq && payload.append('ktNxtq', this.form.ktNxtq);
      this.form.kntcsNxtq && payload.append('kntcsNxtq', this.form.kntcsNxtq);
      this.form.mdrcNxtq && payload.append('mdrcNxtq', this.form.mdrcNxtq);
      this.form.kndctlNxtq &&
        payload.append('kndctlNxtq', this.form.kndctlNxtq);
      this.form.dltdNxtq && payload.append('dltdNxtq', this.form.dltdNxtq);
      this.form.nxtq && payload.append('nxtq', this.form.nxtq);
      this.form.dxvmtNxtq && payload.append('dxvmtNxtq', this.form.dxvmtNxtq);
      this.form.khvhdNxtq && payload.append('khvhdNxtq', this.form.khvhdNxtq);

      let confirm = await this.$swal({
        text: `Bạn có chắc muốn cập nhật thông tin này hay không?`,
        icon: 'warning',
        buttons: {
          cancel: {
            text: 'Huỷ',
            value: false,
            visible: true,
            className: '',
            closeModal: true,
          },
          confirm: {
            text: 'Xác nhận',
            value: true,
            visible: true,
            className: 'btn-success',
            closeModal: true,
          },
        },
      });
      if (confirm) {
        this.handleUpdate(payload);
      }
    },
    async handleUpdate(payload) {
      payload.append('id', this.form.id);
      try {
        this.loading = true;
        await this.$api.put('Admin/SurveyImport/result', payload);
        this.$toastr.s({
          title: 'Thành công!',
          msg: 'Chúc mừng, báo cáo đã được cập nhật!',
        });

        // reaload
        this.loadUserData();
      } catch (e) {
        this.$toastr.e({
          title: 'Lỗi!',
          msg: e.message,
        });
      } finally {
        this.loading = false;
      }
    },

    async loadUserData() {
      if (!this.$route.params.id) return;
      try {
        this.loading = true;
        const id = this.$route.params.id;
        let { data } = await this.$api.get(`Admin/SurveyImport/result/${id}`);
        this.form = data;
        this.form.userGender = this.isGenderOpts.find(
          (e) => e.name === data.userGender,
        );

        this.preview = data.avatar?.url;
      } catch (error) {
        this.$toastr.e({
          title: 'Lỗi!',
          msg: error,
        });
      } finally {
        this.loading = false;
      }
    },
  },
};
</script>
<style lang="scss" scoped>
.pictureInput {
  position: relative;
}
.icon-edit {
  z-index: 100;
  position: absolute;
  top: -15px;
  right: -6px;
  padding: 2px 6px;
  box-shadow: -1px 2px 10px rgba(0, 0, 0, 0.2);
  border-radius: 50%;
  display: flex;
  align-items: center;
  width: fit-content;
  background-color: #fff;
}
.aterisk {
  color: #f64e60;
  font-size: 0.9rem;
}
</style>
