using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace herbstracing.Models;

public partial class dbEntities : DbContext
{
    public dbEntities(DbContextOptions<dbEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<ip2nation> ip2nation { get; set; }

    public virtual DbSet<ip2nationCountries> ip2nationCountries { get; set; }

    public virtual DbSet<pbcatcol> pbcatcol { get; set; }

    public virtual DbSet<pbcatedt> pbcatedt { get; set; }

    public virtual DbSet<pbcatfmt> pbcatfmt { get; set; }

    public virtual DbSet<pbcattbl> pbcattbl { get; set; }

    public virtual DbSet<pbcatvld> pbcatvld { get; set; }

    public virtual DbSet<z_bas_city> z_bas_city { get; set; }

    public virtual DbSet<z_bas_continent> z_bas_continent { get; set; }

    public virtual DbSet<z_bas_contract> z_bas_contract { get; set; }

    public virtual DbSet<z_bas_country> z_bas_country { get; set; }

    public virtual DbSet<z_bas_herbplace> z_bas_herbplace { get; set; }

    public virtual DbSet<z_bas_item> z_bas_item { get; set; }

    public virtual DbSet<z_bas_item_bom> z_bas_item_bom { get; set; }

    public virtual DbSet<z_bas_item_desc> z_bas_item_desc { get; set; }

    public virtual DbSet<z_bas_item_type> z_bas_item_type { get; set; }

    public virtual DbSet<z_bas_pHPLC> z_bas_pHPLC { get; set; }

    public virtual DbSet<z_bas_place> z_bas_place { get; set; }

    public virtual DbSet<z_bas_product> z_bas_product { get; set; }

    public virtual DbSet<z_bas_product_class> z_bas_product_class { get; set; }

    public virtual DbSet<z_bas_province> z_bas_province { get; set; }

    public virtual DbSet<z_bas_recipes> z_bas_recipes { get; set; }

    public virtual DbSet<z_bas_record> z_bas_record { get; set; }

    public virtual DbSet<z_bas_road> z_bas_road { get; set; }

    public virtual DbSet<z_bas_test> z_bas_test { get; set; }

    public virtual DbSet<z_bas_test_item> z_bas_test_item { get; set; }

    public virtual DbSet<z_bas_town> z_bas_town { get; set; }

    public virtual DbSet<z_bas_vendor> z_bas_vendor { get; set; }

    public virtual DbSet<z_bas_video> z_bas_video { get; set; }

    public virtual DbSet<z_bas_zip> z_bas_zip { get; set; }

    public virtual DbSet<z_car_buyitem> z_car_buyitem { get; set; }

    public virtual DbSet<z_car_qty> z_car_qty { get; set; }

    public virtual DbSet<z_cart_order> z_cart_order { get; set; }

    public virtual DbSet<z_cart_order_d> z_cart_order_d { get; set; }

    public virtual DbSet<z_qcm_environment> z_qcm_environment { get; set; }

    public virtual DbSet<z_qcm_environment_d> z_qcm_environment_d { get; set; }

    public virtual DbSet<z_qcm_finish> z_qcm_finish { get; set; }

    public virtual DbSet<z_qcm_finish_bom> z_qcm_finish_bom { get; set; }

    public virtual DbSet<z_qcm_finish_d> z_qcm_finish_d { get; set; }

    public virtual DbSet<z_qcm_item_testitem> z_qcm_item_testitem { get; set; }

    public virtual DbSet<z_sys_address> z_sys_address { get; set; }

    public virtual DbSet<z_sys_iplog> z_sys_iplog { get; set; }

    public virtual DbSet<z_sys_module> z_sys_module { get; set; }

    public virtual DbSet<z_sys_news> z_sys_news { get; set; }

    public virtual DbSet<z_sys_prgcode> z_sys_prgcode { get; set; }

    public virtual DbSet<z_sys_program> z_sys_program { get; set; }

    public virtual DbSet<z_sys_role> z_sys_role { get; set; }

    public virtual DbSet<z_sys_security> z_sys_security { get; set; }

    public virtual DbSet<z_sys_user> z_sys_user { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ip2nation>(entity =>
        {
            entity.HasKey(e => e.ip).HasName("PK_ip");

            entity.HasIndex(e => new { e.ip, e.country }, "IX_ip_nation");

            entity.Property(e => e.country)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<ip2nationCountries>(entity =>
        {
            entity.HasKey(e => e.code);

            entity.Property(e => e.code)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.country)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.iso_code_2)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.iso_code_3)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.iso_country)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<pbcatcol>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => new { e.pbc_tnam, e.pbc_ownr, e.pbc_cnam }, "pbcatc_x").IsUnique();

            entity.Property(e => e.pbc_bmap)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pbc_cmnt)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.pbc_cnam)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.pbc_edit)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.pbc_hdr)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.pbc_init)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.pbc_labl)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.pbc_mask)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.pbc_ownr)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.pbc_ptrn)
                .HasMaxLength(31)
                .IsUnicode(false);
            entity.Property(e => e.pbc_tag)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.pbc_tnam)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<pbcatedt>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => new { e.pbe_name, e.pbe_seqn }, "pbcate_x").IsUnique();

            entity.Property(e => e.pbe_edit)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.pbe_name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.pbe_work)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<pbcatfmt>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.pbf_name, "pbcatf_x").IsUnique();

            entity.Property(e => e.pbf_frmt)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.pbf_name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<pbcattbl>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => new { e.pbt_tnam, e.pbt_ownr }, "pbcatt_x").IsUnique();

            entity.Property(e => e.pbd_ffce)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.pbd_fitl)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pbd_funl)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pbh_ffce)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.pbh_fitl)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pbh_funl)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pbl_ffce)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.pbl_fitl)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pbl_funl)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.pbt_cmnt)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.pbt_ownr)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.pbt_tnam)
                .HasMaxLength(128)
                .IsUnicode(false);
        });

        modelBuilder.Entity<pbcatvld>(entity =>
        {
            entity.HasNoKey();

            entity.HasIndex(e => e.pbv_name, "pbcatv_x").IsUnique();

            entity.Property(e => e.pbv_msg)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.pbv_name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.pbv_vald)
                .HasMaxLength(254)
                .IsUnicode(false);
        });

        modelBuilder.Entity<z_bas_city>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.country_no, e.province_no, e.mno }, "IX_z_bas_city");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.country_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.country_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mename)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mname)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.province_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.province_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_bas_continent>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => e.mno, "IX_z_bas_continent");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.mename)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mname)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_bas_contract>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.user_no, e.mno, e.lot_no }, "IX_z_bas_contract");

            entity.HasIndex(e => new { e.user_no, e.lot_no }, "IX_z_bas_contract_1");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.isclose)
                .HasMaxLength(50)
                .HasDefaultValue("False");
            entity.Property(e => e.isconfirm)
                .HasMaxLength(50)
                .HasDefaultValue("True");
            entity.Property(e => e.item_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.lot_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.place_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.remark)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.user_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_bas_country>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.mno, e.mname }, "IX_z_bas_country");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.continent_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.continent_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.isenabled)
                .HasMaxLength(50)
                .HasDefaultValue("True");
            entity.Property(e => e.mename)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mname)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_bas_herbplace>(entity =>
        {
            entity.HasKey(e => e.rowid).IsClustered(false);

            entity.HasIndex(e => e.mno, "IX_z_bas_herbplace_mno").IsClustered();

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.mapx).HasMaxLength(50);
            entity.Property(e => e.mapy).HasMaxLength(50);
            entity.Property(e => e.mname).HasMaxLength(50);
            entity.Property(e => e.mno).HasMaxLength(50);
        });

        modelBuilder.Entity<z_bas_item>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => e.mno, "IX_z_bas_item");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.cart_price).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.cart_undiscount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.cart_unit).HasMaxLength(50);
            entity.Property(e => e.ispicture)
                .HasMaxLength(50)
                .HasDefaultValue("False");
            entity.Property(e => e.issale)
                .HasMaxLength(50)
                .HasDefaultValue("False");
            entity.Property(e => e.mcode)
                .HasMaxLength(50)
                .HasDefaultValue("M");
            entity.Property(e => e.mename).HasMaxLength(50);
            entity.Property(e => e.mname).HasMaxLength(50);
            entity.Property(e => e.mno).HasMaxLength(50);
            entity.Property(e => e.mparts).HasMaxLength(50);
            entity.Property(e => e.mprice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 4)");
            entity.Property(e => e.msale)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 4)");
            entity.Property(e => e.mtype).HasMaxLength(50);
            entity.Property(e => e.munit).HasMaxLength(50);
            entity.Property(e => e.pictureurl).HasMaxLength(250);
        });

        modelBuilder.Entity<z_bas_item_bom>(entity =>
        {
            entity.HasKey(e => e.rowid).IsClustered(false);

            entity.HasIndex(e => new { e.item_no, e.mno }, "IX_z_bas_item_bom");

            entity.HasIndex(e => new { e.parentid, e.mno }, "IX_z_bas_item_bom_item_no").IsClustered();

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.item_no).HasMaxLength(50);
            entity.Property(e => e.mno).HasMaxLength(50);
            entity.Property(e => e.parentid).HasMaxLength(50);
        });

        modelBuilder.Entity<z_bas_item_desc>(entity =>
        {
            entity.HasKey(e => e.rowid).IsClustered(false);

            entity.HasIndex(e => new { e.msort, e.mname }, "IX_z_bas_item_desc").IsClustered();

            entity.Property(e => e.mname).HasMaxLength(50);
            entity.Property(e => e.msort).HasMaxLength(50);
        });

        modelBuilder.Entity<z_bas_item_type>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.issale)
                .HasMaxLength(50)
                .HasDefaultValue("False");
            entity.Property(e => e.mname)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.msort).HasMaxLength(50);
        });

        modelBuilder.Entity<z_bas_pHPLC>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.Property(e => e.mno).HasMaxLength(50);
            entity.Property(e => e.z_bas_item_bom_no).HasMaxLength(50);
        });

        modelBuilder.Entity<z_bas_place>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.user_no, e.mno }, "IX_z_bas_place");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.area_type)
                .HasMaxLength(250)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.city_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.country_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.earea_type).HasMaxLength(250);
            entity.Property(e => e.emaddress).HasMaxLength(250);
            entity.Property(e => e.emarea).HasMaxLength(50);
            entity.Property(e => e.emfrost).HasMaxLength(50);
            entity.Property(e => e.emhight).HasMaxLength(50);
            entity.Property(e => e.emrain).HasMaxLength(50);
            entity.Property(e => e.emtemperature).HasMaxLength(50);
            entity.Property(e => e.emwater).HasMaxLength(250);
            entity.Property(e => e.etemp_height).HasMaxLength(50);
            entity.Property(e => e.etemp_low).HasMaxLength(50);
            entity.Property(e => e.ismap)
                .HasMaxLength(50)
                .HasDefaultValue("False");
            entity.Property(e => e.maddlead)
                .HasMaxLength(250)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.maddress)
                .HasMaxLength(250)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mapaddr).HasMaxLength(250);
            entity.Property(e => e.mapdesc).HasMaxLength(250);
            entity.Property(e => e.mapx)
                .HasMaxLength(50)
                .HasDefaultValue("0");
            entity.Property(e => e.mapy)
                .HasMaxLength(50)
                .HasDefaultValue("0");
            entity.Property(e => e.marea)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.menvironment).HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mfrost)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mhight)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mname)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mrain)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mtemperature)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mwater)
                .HasMaxLength(250)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.province_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.remark)
                .HasMaxLength(250)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.road_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.temp_height)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.temp_low)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.town_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.user_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_bas_product>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.Property(e => e.rowid).HasComment("產品內容明細");
            entity.Property(e => e.mcontent).HasComment("內容描述");
            entity.Property(e => e.mname).HasMaxLength(50);
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasComment("編號");
            entity.Property(e => e.z_bas_item).HasMaxLength(50);
        });

        modelBuilder.Entity<z_bas_product_class>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.Property(e => e.mname).HasMaxLength(50);
            entity.Property(e => e.mno).HasMaxLength(50);
        });

        modelBuilder.Entity<z_bas_province>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.country_no, e.mno }, "IX_z_bas_province");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.country_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.country_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mename)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mname)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_bas_recipes>(entity =>
        {
            entity.HasKey(e => e.rowid).IsClustered(false);

            entity.HasIndex(e => new { e.mcode, e.msort, e.mname }, "IX_z_bas_recipes").IsClustered();

            entity.Property(e => e.mcode).HasMaxLength(50);
            entity.Property(e => e.mname).HasMaxLength(50);
            entity.Property(e => e.msort).HasMaxLength(50);
        });

        modelBuilder.Entity<z_bas_record>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.vender_no, e.place_no, e.item_no, e.lot_no }, "IX_z_bas_record");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.item_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.lot_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.mdescribe).HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.place_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.vender_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_bas_road>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.country_no, e.province_no, e.city_no, e.town_no, e.mno }, "IX_z_bas_road");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.city_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.city_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.country_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.country_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mname)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.province_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.province_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.town_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.town_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_bas_test>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.mcode)
                .HasMaxLength(100)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mename).HasMaxLength(100);
            entity.Property(e => e.mname)
                .HasMaxLength(100)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mno)
                .HasMaxLength(100)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_bas_test_item>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.mcode, e.seq, e.test_no }, "IX_z_bas_test_item");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.mcode)
                .HasMaxLength(100)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.seq)
                .HasMaxLength(100)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.test_no)
                .HasMaxLength(100)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_bas_town>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.country_no, e.province_no, e.city_no, e.mno }, "IX_z_bas_town");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.city_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.city_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.country_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.country_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mename)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mname)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.province_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.province_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_bas_vendor>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => e.mno, "IX_z_bas_vendor");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.adate).HasComment("核准日期");
            entity.Property(e => e.cdate)
                .HasDefaultValueSql("(getdate())")
                .HasComment("申請日期");
            entity.Property(e => e.city_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.country_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.ismap)
                .HasMaxLength(50)
                .HasDefaultValue("False");
            entity.Property(e => e.maddlead)
                .HasMaxLength(250)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.maddr).HasMaxLength(250);
            entity.Property(e => e.maddress)
                .HasMaxLength(250)
                .HasDefaultValueSql("(space((0)))")
                .HasComment("聯絡地址");
            entity.Property(e => e.mapaddr).HasMaxLength(250);
            entity.Property(e => e.mapdesc).HasMaxLength(250);
            entity.Property(e => e.mapx)
                .HasMaxLength(50)
                .HasDefaultValue("0");
            entity.Property(e => e.mapy)
                .HasMaxLength(50)
                .HasDefaultValue("0");
            entity.Property(e => e.marea).HasMaxLength(50);
            entity.Property(e => e.mboss).HasMaxLength(50);
            entity.Property(e => e.mcode).HasMaxLength(50);
            entity.Property(e => e.mcontactor).HasMaxLength(50);
            entity.Property(e => e.memail)
                .HasMaxLength(250)
                .HasDefaultValueSql("(space((0)))")
                .HasComment("E-MAIL");
            entity.Property(e => e.mfax)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))")
                .HasComment("傳真號碼");
            entity.Property(e => e.mmobil)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))")
                .HasComment("行動電話");
            entity.Property(e => e.mname)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))")
                .HasComment("農戶姓名");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))")
                .HasComment("農戶帳號");
            entity.Property(e => e.mpassword).HasMaxLength(50);
            entity.Property(e => e.mproduct).HasMaxLength(50);
            entity.Property(e => e.mserialno).HasMaxLength(50);
            entity.Property(e => e.msex)
                .HasMaxLength(50)
                .HasDefaultValue("M")
                .HasComment("性    別");
            entity.Property(e => e.msname).HasMaxLength(50);
            entity.Property(e => e.mstatus)
                .HasMaxLength(50)
                .HasDefaultValue("N")
                .HasComment("帳號狀態");
            entity.Property(e => e.mtel)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))")
                .HasComment("連絡電話");
            entity.Property(e => e.mweburl).HasMaxLength(100);
            entity.Property(e => e.mzipno).HasMaxLength(50);
            entity.Property(e => e.province_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.remark)
                .HasMaxLength(250)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.road_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.town_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.userno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))")
                .HasComment("評估人員");
            entity.Property(e => e.vdate).HasComment("評估日期");
        });

        modelBuilder.Entity<z_bas_video>(entity =>
        {
            entity.HasKey(e => e.rowid).IsClustered(false);

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.isenabled).HasMaxLength(50);
            entity.Property(e => e.mcode).HasMaxLength(50);
            entity.Property(e => e.mfile).HasMaxLength(50);
            entity.Property(e => e.mtitle).HasMaxLength(250);
        });

        modelBuilder.Entity<z_bas_zip>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.country_no, e.province_no, e.city_no, e.town_no, e.road_no, e.zip_no }, "IX_z_bas_zip");

            entity.HasIndex(e => new { e.zip_no, e.country_no, e.province_no, e.city_no, e.town_no }, "IX_z_bas_zip_1");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.city_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.city_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.country_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.country_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.province_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.province_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.road_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.road_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.scope_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.town_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.town_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.zip_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_car_buyitem>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.amounts)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 4)");
            entity.Property(e => e.item_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.item_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.price)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 4)");
            entity.Property(e => e.qty)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 4)");
            entity.Property(e => e.sessionid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.unit_no).HasMaxLength(50);
        });

        modelBuilder.Entity<z_car_qty>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.mno)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.seq).HasMaxLength(50);
        });

        modelBuilder.Entity<z_cart_order>(entity =>
        {
            entity.HasKey(e => e.rowid).IsClustered(false);

            entity.HasIndex(e => new { e.sheet_date, e.sheet_no }, "IX_z_cart_order_date_no");

            entity.HasIndex(e => new { e.sheet_date, e.sheet_no, e.target_no }, "IX_z_cart_order_date_target");

            entity.HasIndex(e => new { e.target_no, e.sheet_no }, "IX_z_cart_order_target")
                .IsDescending(false, true)
                .IsClustered();

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.amount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.sheet_code).HasMaxLength(50);
            entity.Property(e => e.sheet_no).HasMaxLength(50);
            entity.Property(e => e.target_name).HasMaxLength(50);
            entity.Property(e => e.target_no).HasMaxLength(50);
        });

        modelBuilder.Entity<z_cart_order_d>(entity =>
        {
            entity.HasKey(e => e.rowid).IsClustered(false);

            entity.HasIndex(e => new { e.sheet_date, e.item_code, e.item_no }, "IX_z_cart_order_d_date_item");

            entity.HasIndex(e => new { e.sheet_date, e.sheet_no, e.seq }, "IX_z_cart_order_d_date_seq");

            entity.HasIndex(e => new { e.sheet_no, e.seq }, "IX_z_cart_order_d_seq").IsClustered();

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.amount).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.item_code).HasMaxLength(50);
            entity.Property(e => e.item_name).HasMaxLength(50);
            entity.Property(e => e.item_no).HasMaxLength(50);
            entity.Property(e => e.price).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.qty).HasColumnType("decimal(18, 4)");
            entity.Property(e => e.remark).HasMaxLength(250);
            entity.Property(e => e.seq).HasMaxLength(50);
            entity.Property(e => e.sheet_no).HasMaxLength(50);
        });

        modelBuilder.Entity<z_qcm_environment>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.mcode, e.user_no, e.place_no, e.lot_no, e.mdate }, "IX_z_qcm_environment");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.handle_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.isconfirm).HasMaxLength(50);
            entity.Property(e => e.lot_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mcode)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.place_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.remark)
                .HasMaxLength(250)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.sdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.user_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_qcm_environment_d>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.mno, e.seq, e.test_no }, "IX_z_qcm_environment_d");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.mcode)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.seq)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.stand_value)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.test_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.test_value)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_qcm_finish>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.plot_no, e.clot_no, e.item_no }, "IX_z_qcm_finish");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.clot_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.isconfirm).HasMaxLength(50);
            entity.Property(e => e.item_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.item_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.plot_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.prod_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.prod_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.remark).HasMaxLength(250);
            entity.Property(e => e.report_no).HasMaxLength(250);
            entity.Property(e => e.slot_no).HasMaxLength(50);
        });

        modelBuilder.Entity<z_qcm_finish_bom>(entity =>
        {
            entity.HasKey(e => e.rowid).IsClustered(false);

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.clot_no).HasMaxLength(50);
            entity.Property(e => e.form_no).HasMaxLength(50);
            entity.Property(e => e.item_no).HasMaxLength(50);
            entity.Property(e => e.plot_no).HasMaxLength(50);
        });

        modelBuilder.Entity<z_qcm_finish_d>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.mno, e.seq, e.test_no }, "IX_z_qcm_finish_d");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.seq)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.test_base)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.test_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.test_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.test_result)
                .HasMaxLength(50)
                .HasDefaultValue("Pass");
            entity.Property(e => e.test_unit)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.test_value)
                .HasMaxLength(100)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_qcm_item_testitem>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.mno).HasMaxLength(50);
            entity.Property(e => e.parentid).HasMaxLength(50);
            entity.Property(e => e.seq).HasMaxLength(50);
            entity.Property(e => e.test_base).HasMaxLength(100);
            entity.Property(e => e.test_name).HasMaxLength(50);
            entity.Property(e => e.test_no).HasMaxLength(50);
            entity.Property(e => e.test_result).HasMaxLength(50);
            entity.Property(e => e.test_unit).HasMaxLength(50);
            entity.Property(e => e.test_value).HasMaxLength(50);
        });

        modelBuilder.Entity<z_sys_address>(entity =>
        {
            entity.HasKey(e => e.rowid).IsClustered(false);

            entity.HasIndex(e => e.parentid, "IX_z_sys_address_parentid").IsClustered();

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.addr_name)
                .HasMaxLength(250)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.city_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.country_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.parentid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.province_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.road_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.town_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_sys_iplog>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.ipaddr).HasMaxLength(50);
            entity.Property(e => e.mcode).HasMaxLength(50);
            entity.Property(e => e.mlotno).HasMaxLength(50);
            entity.Property(e => e.mno).HasMaxLength(50);
            entity.Property(e => e.mtime).HasColumnType("datetime");
        });

        modelBuilder.Entity<z_sys_module>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => e.mno, "IX_z_sys_module_mno");

            entity.HasIndex(e => new { e.isenabled, e.msort, e.mno }, "IX_z_sys_module_msort");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.isenabled)
                .HasMaxLength(50)
                .HasDefaultValue("True");
            entity.Property(e => e.mcode)
                .HasMaxLength(50)
                .HasDefaultValue("APP");
            entity.Property(e => e.mname)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.msort)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_sys_news>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.isenabled)
                .HasMaxLength(50)
                .HasDefaultValue("True");
            entity.Property(e => e.mcode)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mdate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.mdescribe).HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mtime).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.mtitle)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_sys_prgcode>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.module_no, e.msort, e.mno }, "IX_z_sys_prgcode_mno");

            entity.HasIndex(e => new { e.isenabled, e.module_no, e.msort, e.mno }, "IX_z_sys_prgcode_msort");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.isenabled)
                .HasMaxLength(50)
                .HasDefaultValue("True");
            entity.Property(e => e.mname)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.module_no).HasMaxLength(50);
            entity.Property(e => e.msort)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_sys_program>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.isenabled, e.moduleno, e.prgcode, e.msort, e.mno }, "IX_z_sys_program_msort");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.isenabled)
                .HasMaxLength(50)
                .HasDefaultValue("True");
            entity.Property(e => e.mname)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.moduleno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.msort)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.prgcode)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.urlpage)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.urlpath)
                .HasMaxLength(100)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_sys_role>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => e.mno, "IX_z_sys_role_mno").IsUnique();

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.isenabled)
                .HasMaxLength(50)
                .HasDefaultValue("True");
            entity.Property(e => e.mname)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.msort)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_sys_security>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.user_no, e.module_no, e.prg_no }, "IX_z_sys_security");

            entity.HasIndex(e => new { e.module_no, e.prg_no, e.user_no }, "IX_z_sys_security_1");

            entity.HasIndex(e => new { e.user_no, e.prg_no }, "IX_z_sys_security_2");

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.isadd)
                .HasMaxLength(50)
                .HasDefaultValue("True");
            entity.Property(e => e.isconfirm)
                .HasMaxLength(50)
                .HasDefaultValue("True");
            entity.Property(e => e.isdelete)
                .HasMaxLength(50)
                .HasDefaultValue("True");
            entity.Property(e => e.isedit)
                .HasMaxLength(50)
                .HasDefaultValue("True");
            entity.Property(e => e.isenabled)
                .HasMaxLength(50)
                .HasDefaultValue("True");
            entity.Property(e => e.isprint)
                .HasMaxLength(50)
                .HasDefaultValue("True");
            entity.Property(e => e.module_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.prg_name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.prg_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.user_no)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        modelBuilder.Entity<z_sys_user>(entity =>
        {
            entity.HasKey(e => e.rowid);

            entity.HasIndex(e => new { e.mcode, e.mno }, "IX_z_sys_user_mcode_mno");

            entity.HasIndex(e => new { e.mcode, e.roleno }, "IX_z_sys_user_mcode_roleno");

            entity.HasIndex(e => e.mno, "IX_z_sys_user_mno").IsUnique();

            entity.Property(e => e.rowid)
                .HasMaxLength(50)
                .HasDefaultValueSql("(newid())");
            entity.Property(e => e.indate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.isenabled)
                .HasMaxLength(50)
                .HasDefaultValue("True");
            entity.Property(e => e.mcode)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.memail)
                .HasMaxLength(250)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mename)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mname)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mpassword)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.msex)
                .HasMaxLength(50)
                .HasDefaultValue("M");
            entity.Property(e => e.msname)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.mtel)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.orgno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.remark)
                .HasMaxLength(250)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.roleno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
            entity.Property(e => e.userno)
                .HasMaxLength(50)
                .HasDefaultValueSql("(space((0)))");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
