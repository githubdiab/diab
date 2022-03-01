import Vue from 'vue';
import Router from 'vue-router';

Vue.use(Router);

export default new Router({
  mode: 'history',
  duplicateNavigationPolicy: 'reload',
  routes: [
    {
      path: '/',
      component: () => import('@/view/layout/Layout'),
      meta: {
        requiresAuth: true,
      },
      children: [
        {
          path: '/',
          name: 'dashboard',
          component: () => import('@/view/pages/Dashboard.vue'),
        },
        // MANAGE USER GROUPS: BEGIN
        {
          path: 'user_group',
          name: 'user_group_list',
          component: () => import('@/view/pages/user_group/userGroupsList.vue'),
          meta: {
            requiresAuth: true,
            breadcrumb: [
              {
                name: 'Danh sách nhóm người dùng',
                link: 'user_group_list',
                active: true,
              },
            ],
          },
        },
        {
          path: 'user_group/:form_type/:id?',
          name: 'user_group_detail',
          props: true,
          component: () =>
            import('@/view/pages/user_group/userGroupDetail.vue'),
          meta: {
            requiresAuth: true,
            breadcrumb: [
              {
                name: 'Danh sách nhóm người dùng',
                link: 'user_group_list',
              },
              {
                createName: 'Thêm nhóm người dùng',
                editName: 'Chỉnh sửa nhóm người dùng',
                link: 'user_group_detail',
                active: true,
              },
            ],
          },
        },
        // MANAGE USER GROUPS: END
        // MANAGE ACCOUNT PORTAL: BEGIN
        {
          path: 'user_portal',
          name: 'user_portal_list',
          component: () =>
            import('@/view/pages/user_portal/userPortalList.vue'),
          meta: {
            requiresAuth: true,
            breadcrumb: [
              {
                name: 'Danh mục tài khoản Portal',
                link: 'user_portal_list',
                active: true,
              },
            ],
          },
        },
        {
          path: 'user_portal/view/:id',
          name: 'user_portal_view',
          props: true,
          component: () =>
            import('@/view/pages/user_portal/userPortalView.vue'),
          meta: {
            requiresAuth: true,
            breadcrumb: [
              {
                name: 'Danh mục tài khoản Portal',
                link: 'user_portal_list',
              },
              {
                name: 'Chi tiết tài khoản Portal',
                link: 'user_portal_view',
                active: true,
              },
            ],
          },
        },
        {
          path: 'user_portal/:form_type/:id?',
          name: 'user_portal_detail',
          props: true,
          component: () =>
            import('@/view/pages/user_portal/userPortalDetail.vue'),
          meta: {
            requiresAuth: true,
            breadcrumb: [
              {
                name: 'Danh mục tài khoản Portal',
                link: 'user_portal_list',
              },
              {
                createName: 'Thêm mới tài khoản Portal',
                editName: 'Chỉnh sửa tài khoản Portal',
                link: 'user_portal_detail',
                active: true,
              },
            ],
          },
        },
        // MANAGE ACCOUNT PORTAL: END

        // IMPORT BEGIN
        {
          path: 'user_import',
          name: 'user_import_list',
          component: () =>
            import('@/view/pages/user_import/userImportList.vue'),
          meta: {
            requiresAuth: true,
            breadcrumb: [
              {
                name: 'Kết quả khảo sát',
                link: 'user_import',
                active: true,
              },
            ],
          },
        },
        {
          path: 'user_import/:form_type/:id?',
          name: 'user_import_detail',
          props: true,
          component: () =>
            import('@/view/pages/user_import/userImportDetail.vue'),
          meta: {
            requiresAuth: true,
            breadcrumb: [
              {
                name: 'Chi tiết kết quả khảo sát',
                link: 'user_import_list',
              },
              {
                createName: 'Thêm nhóm người dùng',
                editName: 'Chỉnh sửa nhóm người dùng',
                link: 'user_import_detail',
                active: true,
              },
            ],
          },
        },
        // IMPORT END

        // SYSTEM PARAMETER: BEGIN
        {
          path: 'system_parameter',
          name: 'system_parameter',
          component: () =>
            import('@/view/pages/system_parameter/systemParameterList.vue'),
          meta: {
            requiresAuth: true,
            breadcrumb: [
              {
                name: 'Cài đặt',
                link: null,
              },
              {
                name: 'Tham số hệ thống',
                link: 'system_parameter',
                active: true,
              },
            ],
          },
        },
        // SYSTEM PARAMETER: END
        // PROFILE PAGE: BEGIN
        {
          path: 'profile',
          name: 'profile',
          component: () => import('@/view/pages/profile/index.vue'),
          meta: {
            breadcrumb: [
              {
                name: 'Profile',
                link: 'profile',
                active: true,
              },
            ],
          },
        },
        // PROFILE PAGE: END
        // LOADING PAGE: BEGIN
        {
          path: 'loading',
          name: 'loading',
          props: true,
          component: () => import('@/view/pages/user_import/loading.vue'),
          meta: {
            breadcrumb: [
              {
                name: 'Loading',
                link: 'loading',
                active: true,
              },
            ],
          },
        },
        // LOADING PAGE: END

        //VALIDATE PAGE :BEGIN

        {
          path: 'validate',
          name: 'validate',
          props: true,
          component: () =>
            import('@/view/pages/user_import/components/validate.vue'),
          meta: {
            breadcrumb: [
              {
                name: 'Validate',
                link: 'validate',
                active: true,
              },
            ],
          },
        },
        // VALIDATE PAGE : END

        //EXPORT PAGE :BEGIN
        {
          path: 'user_export',
          name: 'user_export_list',
          component: () =>
            import('@/view/pages/user_export/userExportList.vue'),
          meta: {
            requiresAuth: true,
            breadcrumb: [
              {
                name: 'Xuất báo cáo',
                link: 'user_export',
                active: true,
              },
            ],
          },
        },
        {
          path: 'user_export/:form_type/:id?',
          name: 'user_export_detail',
          props: true,
          component: () =>
            import('@/view/pages/user_export/userExportDetail.vue'),
          meta: {
            requiresAuth: true,
            breadcrumb: [
              {
                name: 'Xuất báo cáo',
                link: 'user_export_list',
              },
              {
                editName: 'Chỉnh sửa báo cáo',
                viewName: 'Chi tiết báo cáo',
                link: 'user_export_detail',
                active: true,
              },
            ],
          },
        },
        // EXPORT PAGE : END
      
      ],
    },
  ],
});
